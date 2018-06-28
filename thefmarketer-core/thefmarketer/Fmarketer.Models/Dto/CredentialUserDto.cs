using Fmarketer.Base.Enums;
using Fmarketer.Models.Model;

namespace Fmarketer.Models.Dto
{
    public class CredentialUserDto
    {
        private Credential Credential { get; set; }
        private BaseUser User { get; set; }

        // Base User
        public string FirstName { get { return User.FirstName; } }
        public string LastName { get { return User.LastName; } }
        public string Email { get { return User.Email; } }
        public string Contact { get { return User.Contact; } }

        // User
        public bool ShowEmail { get { return (Credential.UserType == USERTYPES.User) ? ((User)User).ShowEmail : ((Credential.UserType == USERTYPES.Consultant) ? ((Consultant)User).ShowEmail : false); } }
        public bool ShowContact { get { return (Credential.UserType == USERTYPES.User) ? ((User)User).ShowContact : ((Credential.UserType == USERTYPES.Consultant) ? ((Consultant)User).ShowContact : false); } }

        // Consultant
        public string Email2 { get { return (Credential.UserType == USERTYPES.Consultant) ? ((Consultant)User).Email2 : ""; } }
        public string Contact2 { get { return (Credential.UserType == USERTYPES.Consultant) ? ((Consultant)User).Contact2 : ""; } }
        public string ContactOpt { get { return (Credential.UserType == USERTYPES.Consultant) ? ((Consultant)User).ContactOpt.ToString() : ""; } }
        public string ContactOpt2 { get { return (Credential.UserType == USERTYPES.Consultant) ? ((Consultant)User).ContactOpt2.ToString() : ""; } }

        // Credential
        public string UserType { get { return Credential.UserType.ToString(); } }

        public CredentialUserDto(Credential credential, BaseUser user)
        {
            Credential = credential;
            User = user;
        }
    }
}
