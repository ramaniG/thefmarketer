namespace Fmarketer.Models.Model
{
    public class User : BaseUser
    {
        public bool ShowEmail { get; set; }
        public bool ShowContact { get; set; }
        public bool Verified { get; set; }
    }
}
