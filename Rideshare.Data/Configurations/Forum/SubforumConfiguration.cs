using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rideshare.Data.Models.Forum;

namespace Rideshare.Data.Configurations.Forum
{
    public class SubforumConfiguration : IEntityTypeConfiguration<Subforum>
    {
        public void Configure(EntityTypeBuilder<Subforum> builder)
        {
            builder
                .HasMany(s => s.Topics)
                .WithOne(t => t.Subforum)
                .HasForeignKey(t => t.SubforumId);

            builder.Property(s => s.Name).IsRequired();
        }
    }
}

