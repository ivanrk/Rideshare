namespace Rideshare.Web.Areas.Forum.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Rideshare.Services.Forum;
    using System.Threading.Tasks;

    [Area("Forum")]
    public class HomeController : Controller
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
