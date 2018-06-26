using Fmarketer.Models.Model;

namespace Fmarketer.Models.Dto
{
    public class CredentialUserDto
    {
        public Credential Credential { get; set; }
        public BaseUser User { get; set; }

        public CredentialUserDto(Credential credential, BaseUser user)
        {
            Credential = credential;
            User = user;
        }
    }
}
