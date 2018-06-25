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

        public SecurityTokenBU(SecurityTokenRepository securityToken, UserRepository user, ConsultantRepository consultant, AdminRepository admin)
        {
            securityTokenRepository = securityToken;
            userRepository = user;
            consultantRepository = consultant;
            adminRepository = admin;
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

            CredentialUserDto users = null;

            // Find User
            switch (credential.UserType) {
                case USERTYPES.User:
                    users = new CredentialUserDto(credential, await userRepository.FindByCredentialAsync(credential.Id));
                    break;
                case USERTYPES.Consultant:
                    users = new CredentialUserDto(credential, await consultantRepository.FindByCredentialAsync(credential.Id));
                    break;
                case USERTYPES.Admin:
                    users = new CredentialUserDto(credential, await adminRepository.FindByCredentialAsync(credential.Id));
                    break;
                case USERTYPES.SuperAdmin:
                    break;
                default:
                    break;
            }

            if (users == null) {
                throw new InvalidOperationException(ErrorMessage.USERMGMT_UNAUTHORIZED);
            }

            return users;
        }
    }
}
