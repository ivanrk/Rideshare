using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rideshare.Model;

namespace Rideshare.Data.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder
                .HasOne(m => m.Recipient)
                .WithMany(r => r.Messages)
                .HasForeignKey(m => m.RecipientId);

            builder.Property(m => m.Title).IsRequired();
            builder.Property(m => m.Content).IsRequired();
        }
    }
}
