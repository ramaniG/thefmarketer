using Fmarkerter.Base;
using Fmarkerter.Base.Enums;
using System;

namespace Fmarketer.Models
{
    public class BaseUser : BaseEntity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public AuthenticationType AuthType { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
