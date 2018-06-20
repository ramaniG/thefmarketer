using Fmarketer.Base;
using System;

namespace Fmarketer.Models.Model
{
    public class Review : BaseEntity<Guid>
    {
        public int Star { get; set; }
        public string Message { get; set; }
        public bool IsPublic { get; set; }
    }
}
