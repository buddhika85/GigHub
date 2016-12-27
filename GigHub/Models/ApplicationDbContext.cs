using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace GigHub.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        // Custom database tables
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<Following> Following { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Following>()
                .HasRequired(f => f.Artist)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Following>()
                .HasRequired(f => f.User)
                .WithMany()
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}