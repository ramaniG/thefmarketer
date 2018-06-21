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

        public AuthenticationBU(CredentialRepository credentialRepository, SecurityTokenRepository securityTokenRepository)
        {
            this.credentialRepository = credentialRepository;
            this.securityTokenRepository = securityTokenRepository;
        }

        public async Task<LoginOutDto> LoginByEmailAsync(LoginDto dto)
        {
            var credential = credentialRepository.FindByEmail(dto.Email);

            if (credential != null && credential.AuthType == AUTHTYPES.Email && credential.CredentialState == CREDENTIALSTATUS.Active && credential.Verified) {
                if (BCrypt.BCryptHelper.CheckPassword(dto.Password, credential.Password)) {
                    credential.LastLogin = DateTime.Now;
                    credentialRepository.Update(credential);

                    var token = await CreateSecurityTokenAsync(credential);

                    return new LoginOutDto(credential, token);
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

            return await securityTokenRepository.AddAsync(token);
        }
    }
}
