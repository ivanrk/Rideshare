namespace Rideshare.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Rideshare.Services.Admin.Forum;
    using Rideshare.Web.Areas.Admin.Models.Subforums;
    using System.Linq;
    using System.Threading.Tasks;

    public class SubforumsController : BaseController
    {
        private readonly ICategoryService categories;
        private readonly ISubforumService subforums;

        public SubforumsController(ICategoryService categories, ISubforumService subforums)
        {
            this.categories = categories;
            this.subforums = subforums;
        }

        public async Task<IActionResult> Index()
            => View(await this.subforums.AllAsync());

        public async Task<IActionResult> Create()
        {
            var categories = await this.categories.AllAsync();

            var categoriesList = categories.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });

            return View(new SubforumFormViewModel { Categories = categoriesList });
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubforumFormViewModel model)
        {
            await this.subforums.CreateAsync(model.Name, model.SelectedCategory);

            return RedirectToAction(nameof(Index));
        }
    }
}
