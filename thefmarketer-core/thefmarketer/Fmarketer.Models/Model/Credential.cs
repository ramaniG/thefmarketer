using Fmarketer.Base;
using Fmarketer.Base.Enums;
using System;

namespace Fmarketer.Models.Model
{
    public class Credential : BaseEntity<Guid>
    {
        public AUTHTYPES AuthType { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public int NumberOfTry { get; set; }
        public DateTime LastLogin { get; set; }
        public CREDENTIALSTATUS CredentialState { get; set; }
        public USERTYPES UserType { get; set; }
        public bool Verified { get; set; }
        public Consultant _Consultant { get; set; }
        public User _User { get; set; }
        public Admin _Admin { get; set; }
    }
}
