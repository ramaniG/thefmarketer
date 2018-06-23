using Fmarketer.Models.Model;
using System.Collections.Generic;

namespace Fmarketer.Models.Dto
{
    public class GetUsersOutputDto
    {
        public List<GetUserOutputDto> Users { get; set; }
    }

    public class GetUserOutputDto
    {
        public Admin Admin { get; set; }
        public Consultant Consultant { get; set; }
        public User User { get; set; }

        public GetUserOutputDto(Credential credential, BaseUser user)
        {
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
