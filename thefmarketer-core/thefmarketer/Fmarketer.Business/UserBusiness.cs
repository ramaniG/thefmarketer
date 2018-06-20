using Fmarketer.Base;
using Fmarketer.Base.Enums;
using Fmarketer.DataAccess.Repository;
using Fmarketer.Models.Dto;
using Fmarketer.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fmarketer.Business
{
    public class UserBusiness
    {
        CredentialRepository credentialRepository;
        SecurityTokenRepository securityTokenRepository;
        ConsultantRepository consultantRepository;

        public UserBusiness(CredentialRepository credentialRepository, SecurityTokenRepository securityTokenRepository, ConsultantRepository consultantRepository)
        {
            this.credentialRepository = credentialRepository;
            this.securityTokenRepository = securityTokenRepository;
            this.consultantRepository = consultantRepository;
        }

        public async Task<SearchConsultantOutputDto> SearchAsync(SearchConsultantDto dto)
        {
            // Check Credential
            var credential = await CheckTokenAsync(dto.Token);

            var consultants = this.consultantRepository.Find(c => !c.IsDeleted &&
                (c.FirstName + " " + c.LastName).Contains(dto.Name) &&
                c._Coverage.Any(v => v.State == dto.State.Value || !dto.State.HasValue) &&
                c._Service.Any(s => s.Service == dto.Service.Value || !dto.Service.HasValue) &&
                (c._Request.Average(r => r._Review.Star) >= dto.MinRating.Value || !dto.MinRating.HasValue) &&
                (c._Request.Average(r => r._Review.Star) <= dto.MaxRating.Value || !dto.MaxRating.HasValue));

            return new SearchConsultantOutputDto(consultants.ToList());
        }

        private async Task<Credential> CheckTokenAsync(string token)
        {
            var secToken = await securityTokenRepository.CheckAndUpdateAsync(new Guid(token));

            if (secToken == null) {
                throw new UnauthorizedAccessException(ErrorMessage.USERMGMT_UNAUTHORIZED);
            }

            var credential = secToken._Credential;

            if (credential == null || credential.UserType != USERTYPES.User) {
                throw new UnauthorizedAccessException(ErrorMessage.USERMGMT_UNAUTHORIZED);
            }


            return secToken._Credential;
        }

    }
}
