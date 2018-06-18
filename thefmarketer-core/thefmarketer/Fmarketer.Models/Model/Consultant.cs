using Fmarkerter.Base.Enums;

namespace Fmarketer.Models.Model
{
    public class Consultant : User
    {
        public string Email2 { get; set; }
        public string Contact2 { get; set; }
        public CONTACTOPTS ContactOpt { get; set; }
        public CONTACTOPTS ContactOpt2 { get; set; }
    }
}
