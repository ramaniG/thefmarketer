using Fmarketer.Base;
using Fmarketer.Base.Enums;
using Fmarketer.DataAccess.Repository;
using Fmarketer.Models;
using Fmarketer.Models.Dto;
using System;
using System.Threading.Tasks;

namespace Fmarketer.Business
{
    public class SecurityTokenBU
    {
        SecurityTokenRepository securityTokenRepository;
        UserRepository userRepository;
        ConsultantRepository consultantRepository;
        AdminRepository adminRepository;

        UnitOfWork unitOfWork;

        public SecurityTokenBU(UnitOfWork unit, SecurityTokenRepository securityToken, UserRepository user, ConsultantRepository consultant, AdminRepository admin)
        {
            securityTokenRepository = securityToken;
            userRepository = user;
            consultantRepository = consultant;
            adminRepository = admin;

            unitOfWork = unit;
        }

        public async Task<CredentialUserDto> CheckTokenAsync(string token)
        {
            var secToken = await securityTokenRepository.CheckAndUpdateAsync(new Guid(token));

            if (secToken == null) {
                throw new UnauthorizedAccessException(ErrorMessage.USERMGMT_UNAUTHORIZED);
            }

            var credential = secToken._Credential;

            if (credential == null) {
                throw new UnauthorizedAccessException(ErrorMessage.USERMGMT_UNAUTHORIZED);
            }
            
            await unitOfWork.Complete();

            // Find User
            switch (credential.UserType) {
                case USERTYPES.User:
                    return new CredentialUserDto(credential, userRepository.FindByCredential(credential.Id));
                case USERTYPES.Consultant:
                    return new CredentialUserDto(credential, consultantRepository.FindByCredential(credential.Id));
                case USERTYPES.Admin:
                    return new CredentialUserDto(credential, adminRepository.FindByCredential(credential.Id));
                case USERTYPES.SuperAdmin:
                    break;
                default:
                    break;
            }


            throw new InvalidOperationException(ErrorMessage.USERMGMT_UNAUTHORIZED);
        }
    }
}
