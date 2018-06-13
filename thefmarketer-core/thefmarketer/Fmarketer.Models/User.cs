using Fmarkerter.Base;
using Fmarkerter.Base.Enums;
using System;

namespace Fmarketer.Models
{
    public class User : BaseUser
    {
        public bool ShowEmail { get; set; }
        public bool ShowContact { get; set; }
        public bool Verified { get; set; }
    }
}
