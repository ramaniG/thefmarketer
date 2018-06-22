using Fmarketer.Models.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fmarketer.Models
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {
            Admins.Include(a => a._Credential).ToListAsync();
            Chats.Include(c => c._Request).ToListAsync();
            SecurityTokens.Include(s => s._Credential).ToListAsync();
            Consultants.Include(a => a._Credential).Include(c => c._Coverages).Include(c => c._Requests).Include(c => c._Services).ToListAsync();
            Users.Include(a => a._Credential).ToListAsync();
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
            // Admin
            modelBuilder.Entity<Admin>(ConfigureAdmin);

            // Chat
            modelBuilder.Entity<Chat>(builder => builder.HasQueryFilter(x => !x.IsDeleted));

            // Consultant
            modelBuilder.Entity<Consultant>(ConfigureConsultant);
            modelBuilder.Entity<Consultant>().HasMany(c => c._Services).WithOne(s => s._Consultant);
            modelBuilder.Entity<Consultant>().HasMany(c => c._Coverages).WithOne(s => s._Consultant);
            modelBuilder.Entity<Consultant>().HasMany(c => c._Requests).WithOne(s => s._Consultant);

            // Coverage
            modelBuilder.Entity<ConsultantCoverage>(builder => builder.HasQueryFilter(x => !x.IsDeleted));

            // Service
            modelBuilder.Entity<ConsultantService>(builder => builder.HasQueryFilter(x => !x.IsDeleted));

            // Credential
            modelBuilder.Entity<Credential>(ConfigureCredential);

            // Request
            modelBuilder.Entity<Request>(builder => builder.HasQueryFilter(x => !x.IsDeleted));

            // Review
            modelBuilder.Entity<Review>(builder => builder.HasQueryFilter(x => !x.IsDeleted));

            // Security
            modelBuilder.Entity<SecurityToken>(builder => builder.HasQueryFilter(x => !x.IsDeleted));

            // User
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
