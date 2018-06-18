using System;
using System.ComponentModel.DataAnnotations;

namespace thefmarketer.Models
{
    public class User : UserBaseModel
    {
        public enum AuthTypes
        {
            Facebook,
            Google,
            Email
        }

        [Required]
        public AuthTypes AuthType { get; set; } // = models.CharField(max_length=2, choices=AUTHTYPES, default=EM)
        public bool? ShowEmail { get; set; } // = models.NullBooleanField(blank=True)
        public bool? ShowMobile { get; set; } // = models.NullBooleanField(blank=True)
        public DateTime LastLogin { get; set; } // = models.DateTimeField(blank=True)

        public void Update (User user)
        {
            if (Id != user.Id)
            {
                throw new NotSupportedException("Passed ID does not match the parent ID");
            }

            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            MobileNo = user.MobileNo;
            AuthType = user.AuthType;
            Password = user.Password;
            ShowEmail = user.ShowEmail;
            ShowMobile = user.ShowMobile;
            Verified = user.Verified;
        }
    }
}
