namespace Fmarketer.Models.Dto
{
    public class UpdateRequestDto
    {
        public string Token { get; set; }
        public string RequestId { get; set; }
        public bool? IsActive { get; set; }
    }
}
