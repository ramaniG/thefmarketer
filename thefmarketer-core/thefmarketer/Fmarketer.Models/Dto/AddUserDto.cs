using Fmarketer.Base.Enums;
using System.Collections.Generic;

namespace Fmarketer.Models.Dto
{
    public class AddUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Email2 { get; set; }
        public string Contact2 { get; set; }
        public bool ShowEmail { get; set; }
        public bool ShowContact { get; set; }
        public CONTACTOPTS ContactOpt { get; set; }
        public CONTACTOPTS ContactOpt2 { get; set; }
        public AUTHTYPES AuthType { get; set; }
        public string Password { get; set; }
        public USERTYPES UserType { get; set; }
    }
}
