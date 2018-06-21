using System.Collections.Generic;

namespace Fmarketer.Models.Model
{
    public class User : BaseUser
    {
        public bool ShowEmail { get; set; }
        public bool ShowContact { get; set; }

        public List<Request> _Requests { get; set; }
    }
}
