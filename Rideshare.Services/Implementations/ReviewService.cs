namespace Rideshare.Services.Implementations
{
    using Microsoft.EntityFrameworkCore;
    using Rideshare.Data;
    using Rideshare.Model;
    using Rideshare.Service.Contracts;
    using System.Threading.Tasks;

    public class ReviewService : IReviewService
    {
        private readonly RideshareDbContext db;

        public ReviewService(RideshareDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(string userId, int rating, string comment, string authorId)
        {
            var review = new Review
            {
                UserId = userId,
                Rating = rating,
                Comment = comment,
                AuthorId = authorId
            };

            this.db.Add(review);

            await this.db.SaveChangesAsync();
        }

        public async Task<bool> ContainsUsers(string userId, string authorId)
        {
            var match = await this.db.Reviews.AnyAsync(r => r.UserId == userId && r.AuthorId == authorId);

            if (match)
            {
                return true;
            }

            return false;
        }
    }
}
