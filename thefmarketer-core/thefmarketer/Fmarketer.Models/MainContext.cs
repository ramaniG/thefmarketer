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
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Consultant> Consultants { get; set; }
        public DbSet<ConsultantCoverage> Consultantcoverages { get; set; }
        public DbSet<ConsultantService> ConsultantServices { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<SecurityToken> SecurityTokens { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(ConfigureAdmin);
            modelBuilder.Entity<Chat>(builder => builder.HasQueryFilter(x => !x.IsDeleted));
            modelBuilder.Entity<Consultant>(ConfigureConsultant);
            modelBuilder.Entity<ConsultantCoverage>(builder => builder.HasQueryFilter(x => !x.IsDeleted));
            modelBuilder.Entity<ConsultantService>(builder => builder.HasQueryFilter(x => !x.IsDeleted));
            modelBuilder.Entity<Credential>(ConfigureCredential);
            modelBuilder.Entity<Request>(builder => builder.HasQueryFilter(x => !x.IsDeleted));
            modelBuilder.Entity<Review>(builder => builder.HasQueryFilter(x => !x.IsDeleted));
            modelBuilder.Entity<SecurityToken>(builder => builder.HasQueryFilter(x => !x.IsDeleted));
            modelBuilder.Entity<User>(ConfigureUser);
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

        private void ConfigureCredential(EntityTypeBuilder<Credential> builder)
        {
            builder.HasIndex(p => p.Email).IsUnique();
            builder.HasQueryFilter(x => !x.IsDeleted);
        }

        private void ConfigureAdmin(EntityTypeBuilder<Admin> builder)
        {
            builder.HasIndex(p => p.Email).IsUnique();
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
