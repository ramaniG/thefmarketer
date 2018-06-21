using Fmarketer.Base.Enums;

namespace Fmarketer.Models.Dto
{
    public class CreateRequestDto
    {
        public string Token { get; set; }
        public string Message { get; set; }
        public SERVICES Service { get; set; }
        public string ConsultantId { get; set; }
    }
}
