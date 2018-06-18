using Fmarkerter.Base;
using Fmarkerter.Base.Enums;
using System;

namespace Fmarketer.Models.Model
{
    public class Request : BaseEntity<Guid>
    {
        public string Message { get; set; }
        public bool IsActive { get; set; }
        public bool IsCompleted { get; set; }
        public SERVICES Service { get; set; }
        public Review _Review { get; set; }
        public Consultant _Consultant { get; set; }
        public User _User { get; set; }
    }
}
