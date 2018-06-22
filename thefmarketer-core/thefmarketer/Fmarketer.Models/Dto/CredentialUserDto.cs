using Fmarketer.Models.Model;

namespace Fmarketer.Models.Dto
{
    public class CredentialUserDto
    {
        public Credential Credential { get; set; }
        public Admin Admin { get; set; }
        public Consultant Consultant { get; set; }
        public User User { get; set; }

        public CredentialUserDto(Credential credential, BaseUser user)
        {
            Credential = credential;
            switch (credential.UserType) {
                case Base.Enums.USERTYPES.User:
                    User = (User)user;
                    break;
                case Base.Enums.USERTYPES.Consultant:
                    Consultant = (Consultant)user;
                    break;
                case Base.Enums.USERTYPES.Admin:
                    Admin = (Admin)user;
                    break;
                case Base.Enums.USERTYPES.SuperAdmin:
                    break;
                default:
                    break;
            }
        }
    }
}
