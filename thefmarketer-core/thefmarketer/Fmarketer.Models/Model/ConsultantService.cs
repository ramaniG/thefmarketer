using Fmarkerter.Base;
using Fmarkerter.Base.Enums;
using System;

namespace Fmarketer.Models.Model
{
    public class ConsultantService : BaseEntity<Guid>
    {
        public string Company { get; set; }
        public bool LicenseActive { get; set; }
        public string RegistrationNo { get; set; }
        public DateTime ActiveSince { get; set; }
        public int YearsOfExp { get; set; }
        public CLIENTSCALES ClientScale { get; set; }
        public string Proof { get; set; }
        public Consultant _Consultant { get; set; }
    }
}
