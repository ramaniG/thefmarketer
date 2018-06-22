using Fmarketer.Base.Enums;

namespace Fmarketer.Models.Dto
{
    public class UpdateStateDto
    {
        public string Token { get; set; }
        public string CoverageId { get; set; }
        public STATES? State { get; set; }
        public string Location { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
