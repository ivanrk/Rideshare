namespace Rideshare.Services.Admin.Forum.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Rideshare.Data;
    using Rideshare.Data.Models.Forum;
    using Rideshare.Services.Models.Forum;

    public class CategoryService : ICategoryService
    {
        private readonly RideshareDbContext db;

        public CategoryService(RideshareDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<CategoryListingModel>> AllAsync()
            => await this.db.Categories
            .Select(c => new CategoryListingModel { Id = c.Id, Name = c.Name})
            .ToListAsync();

        public async Task CreateAsync(string name)
        {
            var categoryExists = await this.db.Categories.AnyAsync(c => c.Name == name);

            if (!categoryExists)
            {
                var category = new Category { Name = name };
                this.db.Categories.Add(category);
                await this.db.SaveChangesAsync();
            }
        }
    }
}
