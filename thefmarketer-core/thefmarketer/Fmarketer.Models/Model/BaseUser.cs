using Fmarketer.Base;
using System;

namespace Fmarketer.Models.Model
{
    public abstract class BaseUser : BaseEntity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public Credential _Credential { get; set; }
    }
}
