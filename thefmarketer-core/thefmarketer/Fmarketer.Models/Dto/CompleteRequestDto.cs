namespace Fmarketer.Models.Dto
{
    public class CompleteRequestDto
    {
        public string Token { get; set; }
        public string RequestId { get; set; }
        public int Star { get; set; }
        public string Message { get; set; }
        public bool IsPublic { get; set; }
    }
}
