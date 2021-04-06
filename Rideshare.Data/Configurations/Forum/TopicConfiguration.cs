using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rideshare.Data.Models.Forum;

namespace Rideshare.Data.Configurations.Forum
{
    public class TopicConfiguration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder
                .HasMany(t => t.Replies)
                .WithOne(r => r.Topic)
                .HasForeignKey(r => r.TopicId);

            builder
                .HasOne(t => t.Author)
                .WithMany(a => a.ForumTopics)
                .HasForeignKey(t => t.AuthorId);

            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.Content).IsRequired();
        }
    }
}
