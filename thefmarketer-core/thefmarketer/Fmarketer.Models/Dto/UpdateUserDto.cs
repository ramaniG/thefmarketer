using Fmarketer.Base.Enums;

namespace Fmarketer.Models.Dto
{
    public class UpdateUserDto
    {
        public string Token { get; set; }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Contact { get; set; }
        public string Email2 { get; set; }
        public string Contact2 { get; set; }
        public bool? ShowEmail { get; set; }
        public bool? ShowContact { get; set; }
        public CONTACTOPTS? ContactOpt { get; set; }
        public CONTACTOPTS? ContactOpt2 { get; set; }
        public string Password { get; set; }
        public CREDENTIALSTATUS? CredentialState { get; set; }
        public int? NumberOfTry { get; set; }
        public bool? Verified { get; set; }
    }
}
