using Fmarketer.Models.Model;

namespace Fmarketer.Models.Dto
{
    public class LoginOutDto
    {
        private SecurityToken SecurityToken { get; set; }

        public CredentialUserDto User { get; set; }
        public string Token { get { return SecurityToken.Id.ToString(); } }

        public LoginOutDto(Credential credential, SecurityToken securityToken, BaseUser user)
        {
            User = new CredentialUserDto(credential, user);
            SecurityToken = securityToken;
        }
    }
}
