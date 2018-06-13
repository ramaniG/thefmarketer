using Microsoft.EntityFrameworkCore;

namespace thefmarketer.Models
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) {
        }

        public DbSet<User> UserItems { get; set; }
    }
}
