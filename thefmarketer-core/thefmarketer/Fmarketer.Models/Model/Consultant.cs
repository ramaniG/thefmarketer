using Fmarketer.Base.Enums;
using System.Collections.Generic;

namespace Fmarketer.Models.Model
{
    public class Consultant : BaseUser
    {
        public bool ShowEmail { get; set; }
        public bool ShowContact { get; set; }
        public string Email2 { get; set; }
        public string Contact2 { get; set; }
        public CONTACTOPTS ContactOpt { get; set; }
        public CONTACTOPTS ContactOpt2 { get; set; }

        public List<ConsultantCoverage> _Coverages { get; set; }
        public List<ConsultantService> _Services { get; set; }
        public List<Request> _Requests { get; set; }
    }
}
