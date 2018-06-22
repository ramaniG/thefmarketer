using Fmarketer.Base;
using Fmarketer.Base.Enums;
using Fmarketer.DataAccess.Repository;
using Fmarketer.Models.Dto;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Fmarketer.Business
{
    public class AdminBU
    {
        SecurityTokenRepository securityTokenRepository;
        ConsultantRepository consultantRepository;
        RequestRepository requestRepository;
        AdminRepository adminRepository;
        SecurityTokenBU securityTokenBU;

        public AdminBU(SecurityTokenRepository securityToken, ConsultantRepository consultant, RequestRepository request, AdminRepository admin)
        {
            securityTokenRepository = securityToken;
            consultantRepository = consultant;
            requestRepository = request;
            adminRepository = admin;

            securityTokenBU = new SecurityTokenBU(securityTokenRepository, null, null, admin);
        }

        public async Task<SearchConsultantOutputDto> SearchConsultantAsync(SearchConsultantDto dto)
        {
            // Check Credential
            var credential = await securityTokenBU.CheckTokenAsync(dto.Token);

            var consultants = consultantRepository.Find(c => !c.IsDeleted &&
                ((c.FirstName + " " + c.LastName).Contains(dto.Name) || string.IsNullOrEmpty(dto.Name)) &&
                c._Coverages.Any(v => v.State == dto.State.Value || !dto.State.HasValue) &&
                c._Services.Any(s => s.Service == dto.Service.Value || !dto.Service.HasValue) &&
                (c._Requests.Average(r => r._Review.Star) >= dto.MinRating.Value || !dto.MinRating.HasValue) &&
                (c._Requests.Average(r => r._Review.Star) <= dto.MaxRating.Value || !dto.MaxRating.HasValue));

            return new SearchConsultantOutputDto(consultants.ToList());
        }
        
        public async Task<SearchRequestOutputDto> SearchRequestAsync(SearchRequestDto dto)
        {
            // Check Credential
            var credential = await securityTokenBU.CheckTokenAsync(dto.Token);

            if (credential.Credential.UserType == USERTYPES.Admin) {
                var requests = requestRepository.Find(r => (r.Service == dto.Service.Value || !dto.Service.HasValue) &&
                    ((r._Consultant.FirstName + "" + r._Consultant.LastName).Contains(dto.Name) || string.IsNullOrEmpty(dto.Name))).OrderBy(x => x.Updated);

                return new SearchRequestOutputDto(requests.ToList());
            }

            throw new InvalidOperationException(ErrorMessage.USERMGMT_OPERATION_FAILED);
        }

        public async Task UpdateRequestAsync(UpdateRequestDto dto)
        {
            // Check Credential
            var credential = await securityTokenBU.CheckTokenAsync(dto.Token);
            var request = await requestRepository.Get(new Guid(dto.RequestId));

            if (request != null) {
                if (credential.Credential.UserType == USERTYPES.Admin) {
                    if (!request.IsCompleted) {
                        request.IsActive = dto.IsActive ?? request.IsActive;
                        requestRepository.Update(request);
                    }
                }
            }

            throw new InvalidOperationException(ErrorMessage.USERMGMT_OPERATION_FAILED);
        }
    }
}
