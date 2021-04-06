using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rideshare.Model;

namespace Rideshare.Data.Configurations
{
    public class PassengerTravelConfiguration : IEntityTypeConfiguration<PassengerTravel>
    {
        public void Configure(EntityTypeBuilder<PassengerTravel> builder)
        {
            builder
                .HasKey(pt => new { pt.PassengerId, pt.TravelId });

            builder
                .HasOne(t => t.Passenger)
                .WithMany(p => p.Travels)
                .HasForeignKey(t => t.PassengerId);

            builder
                .HasOne(p => p.Travel)
                .WithMany(t => t.Passengers)
                .HasForeignKey(p => p.TravelId);
        }
    }
}
