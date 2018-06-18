using Fmarkerter.Base;
using Fmarkerter.Base.Enums;
using System;

namespace Fmarketer.Models.Model
{
    public class ConsultantCoverage : BaseEntity<Guid>
    {
        public STATES State { get; set; }
        public string Location { get; set; }
        public Consultant _Consultant { get; set; }
    }
}
