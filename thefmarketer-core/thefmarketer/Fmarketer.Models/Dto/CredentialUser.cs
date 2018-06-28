using Fmarketer.Models.Model;

namespace Fmarketer.Models.Dto
{
    public class CredentialUser
    {
        public Credential Credential { get; set; }
        public BaseUser User { get; set; }

        public CredentialUser(Credential credential, BaseUser user)
        {
            Credential = credential;
            User = user;
        }
    }
}
