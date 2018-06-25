using Fmarketer.Models.Model;

namespace Fmarketer.Models.Dto
{
    public class LoginOutDto
    {
        public CredentialUserDto CredentialUser { get; set; }
        public SecurityToken SecurityToken { get; set; }

        public LoginOutDto(Credential credential, SecurityToken securityToken, BaseUser user)
        {
            CredentialUser = new CredentialUserDto(credential, user);
            SecurityToken = securityToken;
        }
    }
}
