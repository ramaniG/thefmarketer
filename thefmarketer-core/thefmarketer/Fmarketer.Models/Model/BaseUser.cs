using Fmarkerter.Base;
using Fmarkerter.Base.Enums;
using System;

namespace Fmarketer.Models.Model
{
    public class BaseUser : BaseEntity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public AUTHTYPES AuthType { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
