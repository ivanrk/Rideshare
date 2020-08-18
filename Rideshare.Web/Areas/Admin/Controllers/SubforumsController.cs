namespace Rideshare.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Rideshare.Services.Admin.Forum;
    using Rideshare.Services.Models.Forum;
    using Rideshare.Web.Areas.Admin.Models.Subforums;
    using System.Collections.Generic;
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

        public async Task<IActionResult> Create(int? categoryId)
        {
            var categories = await this.categories.AllAsync();
            var categoriesList = SetCategoriesList(categories);

            var model = new SubforumFormViewModel { Categories = categoriesList };

            if (categoryId != null)
            {
                model.CurrentCategoryId = (int)categoryId;
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubforumFormViewModel model)
        {
            await this.subforums.CreateAsync(model.Name, model.SelectedCategory);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var subforum = await this.subforums.ByIdAsync(id);

            if (subforum == null)
            {
                return BadRequest();
            }

            var categories = await this.categories.AllAsync();
            var categoriesList = SetCategoriesList(categories);

            var model = new SubforumFormViewModel
            {
                Id = id,
                Name = subforum.Name,
                Categories = categoriesList,
                CurrentCategoryId = subforum.CategoryId
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SubforumFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = SetCategoriesList(await this.categories.AllAsync());
                return View(model);
            }

            await this.subforums.EditAsync(model.Id, model.Name, model.SelectedCategory);
            return RedirectToAction(nameof(Index));
        }

        private static IEnumerable<SelectListItem> SetCategoriesList(IEnumerable<CategoryListingModel> categories)
        {
            return categories.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString(),
            });
        }
    }
}
