using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace thefmarketer.Models
{
    public class Consultant : UserBaseModel
    {
        public enum ContactOption
        {
            PrimaryEmail,
            SecondaryEmail,
            PrimaryMobile,
            SecondaryMobile,
        }
        public string Email2 { get; set; }
        public string ContactNo2 { get; set; }
        public ContactOption PreferedContact1 { get; set; }
        public ContactOption PreferedContact2 { get; set; }
    }
}
