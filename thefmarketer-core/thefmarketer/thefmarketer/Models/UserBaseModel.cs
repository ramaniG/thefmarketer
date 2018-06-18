using System.ComponentModel.DataAnnotations;

namespace thefmarketer.Models
{
    public class UserBaseModel : BaseModel
    {
        [Required]
        public string FirstName { get; set; } // = models.CharField(max_length=255, blank=False, unique=True)
        [Required]
        public string LastName { get; set; } // = models.CharField(max_length=255, blank=False, unique=True)
        [Required]
        public string Email { get; set; } // = models.EmailField(max_length=500, blank=False, unique=True)
        public string MobileNo { get; set; } // = models.CharField(max_length=255, blank=True)
        public string Password { get; set; } // = models.CharField(max_length=50, blank=True)
        [Required]
        public bool Verified { get; set; } // = models.BooleanField(blank=True)

        override public string ToString()
        {
            return Id + ") " + FirstName + " " + LastName;
        }
    }
}
