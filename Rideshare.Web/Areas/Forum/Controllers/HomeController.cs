namespace Rideshare.Web.Areas.Forum.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Rideshare.Service.Contracts.Forum;
    using System.Threading.Tasks;

    public class HomeController : BaseController
    {
        private readonly IForumService forum;

        public HomeController(IForumService forum)
        {
            this.forum = forum;
        }

        public async Task<IActionResult> Index()
            => View(await this.forum.ShowAsync());
    }
}
