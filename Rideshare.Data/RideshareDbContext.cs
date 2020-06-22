namespace Rideshare.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Rideshare.Data.Models;

    public class RideshareDbContext : IdentityDbContext<User>
    {
        public RideshareDbContext(DbContextOptions<RideshareDbContext> options)
            : base(options)
        {
        }

        public DbSet<Travel> Travels { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<PassengerTravel>()
                .HasKey(pt => new { pt.PassengerId, pt.TravelId });

            builder
                .Entity<PassengerTravel>()
                .HasOne(t => t.Passenger)
                .WithMany(p => p.Travels)
                .HasForeignKey(t => t.PassengerId);

            builder
                .Entity<PassengerTravel>()
                .HasOne(p => p.Travel)
                .WithMany(t => t.Passengers)
                .HasForeignKey(p => p.TravelId);

            builder
                .Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId);

            builder
                .Entity<Car>()
                .HasOne(c => c.Owner)
                .WithMany(o => o.Cars)
                .HasForeignKey(c => c.OwnerId);

            builder
                .Entity<Message>()
                .HasOne(m => m.Recipient)
                .WithMany(r => r.Messages)
                .HasForeignKey(m => m.RecipientId);

            builder
                .Entity<Car>()
                .HasMany(c => c.Travels)
                .WithOne(t => t.Car)
                .HasForeignKey(t => t.CarId);

            builder
                .Entity<ApplicantTravel>()
                .HasKey(at => new { at.ApplicantId, at.TravelId });

            builder
                .Entity<ApplicantTravel>()
                .HasOne(t => t.Applicant)
                .WithMany(a => a.Applications)
                .HasForeignKey(t => t.ApplicantId);

            builder
                .Entity<ApplicantTravel>()
                .HasOne(p => p.Travel)
                .WithMany(t => t.Applicants)
                .HasForeignKey(p => p.TravelId);

            base.OnModelCreating(builder);
        }
    }
}
