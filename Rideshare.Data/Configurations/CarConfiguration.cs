using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rideshare.Data.Models;

namespace Rideshare.Data.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder
                .HasOne(c => c.Owner)
                .WithMany(o => o.Cars)
                .HasForeignKey(c => c.OwnerId);

            builder
                .HasMany(c => c.Travels)
                .WithOne(t => t.Car)
                .HasForeignKey(t => t.CarId);

            builder.Property(c => c.Make).IsRequired();
            builder.Property(c => c.Model).IsRequired();
            builder.Property(c => c.Color).IsRequired();
        }
    }
}
