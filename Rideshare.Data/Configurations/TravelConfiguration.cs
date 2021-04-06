using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rideshare.Model;

namespace Rideshare.Data.Configurations
{
    public class TravelConfiguration : IEntityTypeConfiguration<Travel>
    {
        public void Configure(EntityTypeBuilder<Travel> builder)
        {
            builder.Property(t => t.StartingPoint).IsRequired();
            builder.Property(t => t.Destination).IsRequired();
        }
    }
}
