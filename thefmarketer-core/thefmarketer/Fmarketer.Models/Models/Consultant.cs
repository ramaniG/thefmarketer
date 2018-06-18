using Fmarkerter.Base.Enums;

namespace Fmarketer.Models
{
    public class Consultant : User
    {
        public string Email2 { get; set; }
        public string Contact2 { get; set; }
        public ContactOption ContactOpt { get; set; }
        public ContactOption ContactOpt2 { get; set; }
    }
}
