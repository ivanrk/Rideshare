namespace Rideshare.Services
{
    using System.Threading.Tasks;

    public interface IReviewService
    {
        Task CreateAsync(string userId, int rating, string comment, string authorId);

        Task<bool> ContainsUsers(string userId, string authorId);
    }
}
