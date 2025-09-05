using Microsoft.EntityFrameworkCore;
using TripSphere.Models;


namespace TripSphere.Data
{
    public class TripsphereDbContext : DbContext
    {
        public TripsphereDbContext(DbContextOptions<TripsphereDbContext> options)
            : base(options) { }

        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<TravelMode> TravelMode { get; set; }
        public DbSet<TravelPlan> TravelPlan { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TravelFeedback> Feedback { get; set; } // ✅ Newly Added

        public DbSet<TripModel> TripModels { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map UserId -> user_id
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(u => u.UserId);
                entity.Property(u => u.UserId).HasColumnName("user_id");
                entity.Property(u => u.Email).HasColumnName("email");
                entity.Property(u => u.Username).HasColumnName("username");
                entity.Property(u => u.Password).HasColumnName("password");
            });

            // Optional: Add constraints/mapping for TravelFeedback if needed
        }
    }
}
