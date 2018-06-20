using Fmarketer.Models.Model;

namespace Fmarketer.Models.Dto
{
    public class AddUserOutputDto
    {
        public Credential Credential { get; set; }

        public AddUserOutputDto(Credential credential)
        {
            Credential = credential;
        }
    }
}
