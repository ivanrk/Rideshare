using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rideshare.Data.Models.Forum;

namespace Rideshare.Data.Configurations.Forum
{
    public class ReplyConfiguration : IEntityTypeConfiguration<Reply>
    {
        public void Configure(EntityTypeBuilder<Reply> builder)
        {
            builder
                .HasOne(r => r.Author)
                .WithMany(a => a.ForumReplies)
                .HasForeignKey(r => r.AuthorId);

            builder.Property(r => r.Content).IsRequired();
        }
    }
}

