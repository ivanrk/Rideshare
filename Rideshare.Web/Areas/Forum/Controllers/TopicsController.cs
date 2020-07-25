namespace Rideshare.Web.Areas.Forum.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Rideshare.Services.Forum;
    using Rideshare.Web.Areas.Forum.Models.Topics;
    using System.Threading.Tasks;

    public class TopicsController : BaseController
    {
        private readonly ITopicService topics;

        public TopicsController(ITopicService topics)
        {
            this.topics = topics;
        }

        public async Task<IActionResult> All(int subforumId)
        {
            var topics = new TopicListingViewModel
            {
                SubforumId = subforumId,
                Topics = await this.topics.BySubforumAsync(subforumId)
            };

            return View(topics);
        }
    }
}
