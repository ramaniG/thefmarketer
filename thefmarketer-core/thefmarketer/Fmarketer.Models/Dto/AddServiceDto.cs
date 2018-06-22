using Fmarketer.Base.Enums;
using System;

namespace Fmarketer.Models.Dto
{
    public class AddServiceDto
    {
        public string Token { get; set; }
        public SERVICES Service { get; set; }
        public string Company { get; set; }
        public bool LicenseActive { get; set; }
        public string RegistrationNo { get; set; }
        public DateTime ActiveSince { get; set; }
        public int YearsOfExp { get; set; }
        public CLIENTSCALES ClientScale { get; set; }
        public string Proof { get; set; }
    }
}
