namespace Rideshare.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Rideshare.Data.Configurations;
    using Rideshare.Data.Configurations.Forum;
    using Rideshare.Model;
    using Rideshare.Model.Forum;

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

        public DbSet<Category> Categories { get; set; }

        public DbSet<Subforum> Subforums { get; set; }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<Reply> Replies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TravelConfiguration());

            builder.ApplyConfiguration(new PassengerTravelConfiguration());

            builder.ApplyConfiguration(new ReviewConfiguration());

            builder.ApplyConfiguration(new UserConfiguration());

            builder.ApplyConfiguration(new MessageConfiguration());

            builder.ApplyConfiguration(new CarConfiguration());

            builder.ApplyConfiguration(new ApplicantTravelConfiguration());

            builder.ApplyConfiguration(new CategoryConfiguration());

            builder.ApplyConfiguration(new SubforumConfiguration());

            builder.ApplyConfiguration(new TopicConfiguration());

            builder.ApplyConfiguration(new ReplyConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
