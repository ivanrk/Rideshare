using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rideshare.Data.Models.Forum;

namespace Rideshare.Data.Configurations.Forum
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasMany(c => c.Subforums)
                .WithOne(s => s.Category)
                .HasForeignKey(s => s.CategoryId);

            builder.Property(c => c.Name).IsRequired();
        }
    }
}
