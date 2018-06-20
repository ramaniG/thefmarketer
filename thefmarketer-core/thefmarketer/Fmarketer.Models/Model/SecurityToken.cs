using Fmarketer.Base;
using System;

namespace Fmarketer.Models.Model
{
    public class SecurityToken : BaseEntity<Guid>
    {
        // Id will be treated as the token
        public DateTime AuthenticatedTime { get; set; }
        public DateTime ExpiryTime { get; set; }
        public Credential _Credential { get; set; }
    }
}
