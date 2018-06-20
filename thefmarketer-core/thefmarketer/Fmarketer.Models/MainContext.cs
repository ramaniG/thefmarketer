using Fmarketer.Models.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fmarketer.Models
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Consultant> Consultants { get; set; }
        public DbSet<ConsultantCoverage> Consultantcoverages { get; set; }
        public DbSet<ConsultantService> ConsultantServices { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Chat> Chats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(ConfigureUser);
            modelBuilder.Entity<Consultant>(ConfigureConsultant);
            modelBuilder.Entity<Request>(ConfigureRequest);
            modelBuilder.Entity<Review>(ConfigureReview);
            modelBuilder.Entity<Chat>(ConfigureChat);
        }

        private void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(p => p.Email).IsUnique();
            builder.HasQueryFilter(x => !x.IsDeleted);
        }

        private void ConfigureConsultant(EntityTypeBuilder<Consultant> builder)
        {
            builder.HasIndex(p => p.Email).IsUnique();
            builder.HasQueryFilter(x => !x.IsDeleted);
        }

        private static void ConfigureRequest(EntityTypeBuilder<Request> builder)
        {
            builder.HasQueryFilter(x => !x.IsDeleted);
        }


        private static void ConfigureReview(EntityTypeBuilder<Review> builder)
        {
            builder.HasQueryFilter(x => !x.IsDeleted);
        }

        private static void ConfigureChat(EntityTypeBuilder<Chat> builder)
        {
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
