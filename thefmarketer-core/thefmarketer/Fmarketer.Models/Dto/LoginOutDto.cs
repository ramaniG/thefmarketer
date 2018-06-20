using Fmarketer.Models.Model;

namespace Fmarketer.Models.Dto
{
    public class LoginOutDto
    {
        public Credential Credential { get; set; }
        public SecurityToken SecurityToken { get; set; }

        public LoginOutDto(Credential credential, SecurityToken securityToken)
        {
            Credential = credential;
            SecurityToken = securityToken;
        }
    }
}
