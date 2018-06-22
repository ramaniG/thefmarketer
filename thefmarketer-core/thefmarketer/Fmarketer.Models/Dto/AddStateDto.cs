using Fmarketer.Base.Enums;

namespace Fmarketer.Models.Dto
{
    public class AddStateDto
    {
        public string Token { get; set; }
        public STATES State { get; set; }
        public string Location { get; set; }
    }
}
