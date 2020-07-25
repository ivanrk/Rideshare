namespace Rideshare.Services.Forum
{
    using Rideshare.Services.Models.Forum.Topics;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITopicService
    {
        Task<IEnumerable<TopicListingModel>> BySubforumAsync(int subforumId);

        Task<TopicDetailsModel> ByIdAsync(int id);

        Task CreateAsync(string name, string content, string authorId, int subforumId);
    }
}
