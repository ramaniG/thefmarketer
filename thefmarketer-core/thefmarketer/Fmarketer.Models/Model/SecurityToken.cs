using Fmarkerter.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fmarketer.Models.Model
{
    public class SecurityToken : BaseEntity<Guid>
    {
        public string AuthToken { get; set; }
        public DateTime AuthenticatedTime { get; set; }
        public DateTime ExpiryTime { get; set; }
        public Credential _Credential { get; set; }
    }
}
