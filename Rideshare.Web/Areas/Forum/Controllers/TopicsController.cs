namespace Rideshare.Web.Areas.Forum.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Rideshare.Data.Models;
    using Rideshare.Services.Forum;
    using Rideshare.Web.Areas.Forum.Models.Replies;
    using Rideshare.Web.Areas.Forum.Models.Topics;
    using System.Threading.Tasks;

    public class TopicsController : BaseController
    {
        private readonly ITopicService topics;
        private readonly IHtmlService html;
        private readonly UserManager<User> userManager;

        public TopicsController(ITopicService topics, IHtmlService html, UserManager<User> userManager)
        {
            this.topics = topics;
            this.html = html;
            this.userManager = userManager;
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

        public async Task<IActionResult> Show(int id)
        {
            var topic = await this.topics.ByIdAsync(id);

            if (topic == null)
            {
                return BadRequest();
            }

            return View(topic);
        }

        public IActionResult Create(int subforumId)
            => View(new TopicFormViewModel { SubforumId = subforumId });

        [HttpPost]
        public async Task<IActionResult> Create(TopicFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Content = this.html.Sanitize(model.Content);
            var authorId = this.userManager.GetUserId(User);
            await this.topics.CreateAsync(model.Name, model.Content, authorId, model.SubforumId);

            return RedirectToAction(nameof(All), new { subforumId = model.SubforumId });
        }

        public IActionResult Reply(int topicId)
            => View(new ReplyFormViewModel { TopicId = topicId });

        [HttpPost]
        public async Task<IActionResult> Reply(ReplyFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Content = this.html.Sanitize(model.Content);
            var authorId = this.userManager.GetUserId(User);
            await this.topics.ReplyAsync(model.Content, authorId, model.TopicId);

            return RedirectToAction(nameof(Show), new { id = model.TopicId });
        }
    }
}
