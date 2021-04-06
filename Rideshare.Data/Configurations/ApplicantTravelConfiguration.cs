using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rideshare.Data.Models;

namespace Rideshare.Data.Configurations
{
    public class ApplicantTravelConfiguration : IEntityTypeConfiguration<ApplicantTravel>
    {
        public void Configure(EntityTypeBuilder<ApplicantTravel> builder)
        {
            builder
                .HasKey(at => new { at.ApplicantId, at.TravelId });

            builder
                .HasOne(t => t.Applicant)
                .WithMany(a => a.Applications)
                .HasForeignKey(t => t.ApplicantId);

            builder
                .HasOne(p => p.Travel)
                .WithMany(t => t.Applicants)
                .HasForeignKey(p => p.TravelId);
        }
    }
}
