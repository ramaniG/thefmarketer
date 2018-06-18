using Fmarketer.Models.Model;
using Microsoft.EntityFrameworkCore;

namespace Fmarketer.Models
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Consultant> Consultants { get; set; }
        public DbSet<ConsultantCoverage> Consultantcoverages { get; set; }
        public DbSet<ConsultantService> ConsultantServices { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
