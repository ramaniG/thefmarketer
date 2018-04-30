using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace thefmarketer.Models
{
    public class User
    {
        public long id { get; set; }
        public string fname { get; set; } // = models.CharField(max_length=255, blank=False, unique=True)
        public string lname { get; set; } // = models.CharField(max_length=255, blank=False, unique=True)
        public string email { get; set; } // = models.EmailField(max_length=500, blank=False, unique=True)
        public string contactno { get; set; } // = models.CharField(max_length=255, blank=True)
        public string authtype { get; set; } // = models.CharField(max_length=2, choices=AUTHTYPES, default=EM)
        public string password { get; set; } // = models.CharField(max_length=50, blank=True)
        public bool? showemail { get; set; } // = models.NullBooleanField(blank=True)
        public bool? showcontactno { get; set; } // = models.NullBooleanField(blank=True)
        public Boolean verified { get; set; } // = models.BooleanField(blank=True)
        public DateTime lastLogin { get; set; } // = models.DateTimeField(blank=True)
        public DateTime created { get; set; } // = models.DateTimeField(auto_now_add=True)
        public DateTime modified { get; set; } // = models.DateTimeField(auto_now=True)

        public void Update (User user)
        {
            if (id != user.id)
            {
                throw new NotSupportedException("Passed ID does not match the parent ID");
            }

            fname = user.fname;
            lname = user.lname;
            email = user.email;
            contactno = user.contactno;
            authtype = user.authtype;
            password = user.password;
            showemail = user.showemail;
            showcontactno = user.showcontactno;
            verified = user.verified;
        }

        override public string ToString()
        {
            return id + ") " + fname + " " + lname;
        }
    }
}
