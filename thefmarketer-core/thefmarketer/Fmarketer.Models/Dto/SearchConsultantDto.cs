using Fmarketer.Base.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fmarketer.Models.Dto
{
    public class SearchConsultantDto
    {
        public string Token { get; set; }
        public double? MinRating { get; set; }
        public double? MaxRating { get; set; }
        public string Name { get; set; }
        public STATES? State { get; set; }
        public SERVICES? Service { get; set; }
    }
}
