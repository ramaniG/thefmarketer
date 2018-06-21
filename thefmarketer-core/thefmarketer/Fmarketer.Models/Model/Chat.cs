using Fmarketer.Base;
using Fmarketer.Base.Enums;
using System;

namespace Fmarketer.Models.Model
{
    public class Chat : BaseEntity<Guid>
    {
        public string Message { get; set; }
        public string Attachment { get; set; }
        public bool IsRead { get; set; }
        public USERTYPES From { get; set; }
        public Request _Request { get; set; }
    }
}
