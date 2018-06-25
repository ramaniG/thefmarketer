using Fmarketer.Base;
using Fmarketer.Base.Enums;
using Fmarketer.DataAccess.Repository;
using Fmarketer.Models.Dto;
using Fmarketer.Models.Model;
using System;
using System.Threading.Tasks;

namespace Fmarketer.Business
{
    public class AuthenticationBU
    {
        CredentialRepository credentialRepository;
        SecurityTokenRepository securityTokenRepository;
        UserRepository userRepository;
        ConsultantRepository consultantRepository;
        AdminRepository adminRepository;

        public AuthenticationBU(CredentialRepository credential, SecurityTokenRepository securityToken, UserRepository user, ConsultantRepository consultant, AdminRepository admin)
        {
            credentialRepository = credential;
            securityTokenRepository = securityToken;
            userRepository = user;
            consultantRepository = consultant;
            adminRepository = admin;
        }

        public async Task<LoginOutDto> LoginByEmailAsync(LoginDto dto)
        {
            var credential = await credentialRepository.FindByEmailAsync(dto.Email);

            if (credential != null && credential.AuthType == AUTHTYPES.Email && credential.CredentialState == CREDENTIALSTATUS.Active && credential.Verified) {
                if (BCrypt.BCryptHelper.CheckPassword(dto.Password, credential.Password)) {
                    credential.LastLogin = DateTime.Now;
                    credentialRepository.Update(credential);

                    var token = await CreateSecurityTokenAsync(credential);

                    // Find User
                    switch (credential.UserType) {
                        case USERTYPES.User:
                            return new LoginOutDto(credential, token, await userRepository.FindByCredentialAsync(credential.Id));
                        case USERTYPES.Consultant:
                            return new LoginOutDto(credential, token, await consultantRepository.FindByCredentialAsync(credential.Id));
                        case USERTYPES.Admin:
                            return new LoginOutDto(credential, token, await adminRepository.FindByCredentialAsync(credential.Id));
                        case USERTYPES.SuperAdmin:
                            break;
                    }
                }
            }

            throw new InvalidOperationException(ErrorMessage.USERMGMT_OPERATION_FAILED);
        }

        public async Task LogoutByEmailAsync(LogoutDto dto)
        {
            var token = await securityTokenRepository.Get(new Guid(dto.Token));

            if (token != null) {
                token.ExpiryTime = DateTime.Now;

                securityTokenRepository.Update(token);
                return;
            }

            throw new InvalidOperationException(ErrorMessage.USERMGMT_OPERATION_FAILED);
        }

        private async Task<SecurityToken> CreateSecurityTokenAsync(Credential credential)
        {
            var token = new SecurityToken() {
                Id = Guid.NewGuid(),
                AuthenticatedTime = credential.LastLogin,
                ExpiryTime = credential.LastLogin.AddMinutes(15), // TODO: Change Minutes to setting file
                _Credential = credential
            };

            token = await securityTokenRepository.AddAsync(token);
            return token;
        }
    }
}
