namespace Fmarketer.Models.Dto
{
    public class GetUserDto
    {
        public string Token { get; set; }

        public GetUserDto(string token)
        {
            Token = token;
        }
    }
}
