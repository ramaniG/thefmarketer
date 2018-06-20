using Fmarketer.Base;
using System;

namespace Fmarketer.Models.Model
{
    public class Chat : BaseEntity<Guid>
    {
        public string Message { get; set; }
        public string Attachment { get; set; }
        public bool IsRead { get; set; }
        public Request _Request { get; set; }
        public User _User { get; set; }
        public Consultant _Consultant { get; set; }
    }
}
