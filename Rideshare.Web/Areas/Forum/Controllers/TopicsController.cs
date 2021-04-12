namespace Rideshare.Web.Areas.Forum.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Rideshare.Model;
    using Rideshare.Service.Contracts.Admin.Forum;
    using Rideshare.Service.Contracts.Forum;
    using Rideshare.Web.Areas.Forum.Models.Replies;
    using Rideshare.Web.Areas.Forum.Models.Topics;
    using System.Threading.Tasks;

    public class TopicsController : BaseController
    {
        private readonly IHtmlService html;
        private readonly ITopicService topics;
        private readonly ISubforumService subforums;
        private readonly UserManager<User> userManager;

        public TopicsController(IHtmlService html, ITopicService topics, ISubforumService subforums, UserManager<User> userManager)
        {
            this.html = html;
            this.topics = topics;
            this.subforums = subforums;
            this.userManager = userManager;
        }

        public async Task<IActionResult> All(int subforumId)
        {
            if (!await SubforumExists(subforumId))
            {
                return NotFound();
            }

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

        [Authorize]
        public async Task<IActionResult> Create(int subforumId)
        {
            if (!await SubforumExists(subforumId))
            {
                return NotFound();
            }

            return View(new TopicFormViewModel { SubforumId = subforumId });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(TopicFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!await SubforumExists(model.SubforumId))
            {
                return BadRequest();
            }

            model.Content = this.html.Sanitize(model.Content);
            var authorId = this.userManager.GetUserId(User);

            await this.topics.CreateAsync(model.Name, model.Content, authorId, model.SubforumId);

            return RedirectToAction(nameof(All), new { subforumId = model.SubforumId });
        }

        [Authorize]
        public async Task<IActionResult> Reply(int topicId)
        {
            if (!await TopicExists(topicId))
            {
                return NotFound();
            }

            return View(new ReplyFormViewModel { TopicId = topicId });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Reply(ReplyFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!await TopicExists(model.TopicId))
            {
                return BadRequest();
            }

            model.Content = this.html.Sanitize(model.Content);
            var authorId = this.userManager.GetUserId(User);
            await this.topics.ReplyAsync(model.Content, authorId, model.TopicId);

            return RedirectToAction(nameof(Show), new { id = model.TopicId });
        }

        private async Task<bool> SubforumExists(int subforumId)
            => await this.subforums.Exists(subforumId);

        private async Task<bool> TopicExists(int topicId)
            => await this.topics.Exists(topicId);
    }
}
