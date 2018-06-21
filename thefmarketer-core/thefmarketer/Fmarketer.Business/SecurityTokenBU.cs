using Fmarketer.Base;
using Fmarketer.Base.Enums;
using Fmarketer.DataAccess.Repository;
using Fmarketer.Models.Model;
using System;
using System.Threading.Tasks;

namespace Fmarketer.Business
{
    public class SecurityTokenBU
    {
        SecurityTokenRepository securityTokenRepository;

        public SecurityTokenBU(SecurityTokenRepository securityTokenRepository)
        {
            this.securityTokenRepository = securityTokenRepository;
        }

        public async Task<Credential> CheckTokenAsync(string token)
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
