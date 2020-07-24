namespace Rideshare.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Rideshare.Services.Admin.Forum;
    using Rideshare.Web.Areas.Admin.Models.Categories;
    using System.Threading.Tasks;

    public class CategoriesController : BaseController
    {
        private readonly ICategoryService categories;

        public CategoriesController(ICategoryService categories)
        {
            this.categories = categories;
        }

        public async Task<IActionResult> Index()
            => View(await this.categories.AllAsync());

        public IActionResult Create()
            => View(new CategoryFormViewModel());

        [HttpPost]
        public async Task<IActionResult> Create(CategoryFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.categories.CreateAsync(model.Name);

            return RedirectToAction(nameof(Index));
        }
    }
}
