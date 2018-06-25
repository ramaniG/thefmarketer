using Fmarketer.Base.Enums;

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
