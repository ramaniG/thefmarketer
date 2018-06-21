using Fmarketer.Base.Enums;

namespace Fmarketer.Models.Dto
{
    public class SearchRequestDto
    {
        public string Token { get; set; }
        public string Name { get; set; }
        public SERVICES? Service { get; set; }
    }
}
