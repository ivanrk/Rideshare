namespace Rideshare.Services.Admin.Forum.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using Rideshare.Data;
    using Rideshare.Data.Models.Forum;
    using Rideshare.Services.Models.Forum;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SubforumService : ISubforumService
    {
        private readonly RideshareDbContext db;

        public SubforumService(RideshareDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<CategorySubforumsModel>> AllAsync()
            => await this.db.Categories
            .ProjectTo<CategorySubforumsModel>()
            .ToListAsync();

        public async Task CreateAsync(string name, int categoryId)
        {
            var subforumExists = await this.db.Subforums.AnyAsync(sf => sf.Name == name);

            if (!subforumExists)
            {
                var subforum = new Subforum { Name = name, CategoryId = categoryId };
                this.db.Subforums.Add(subforum);
                await this.db.SaveChangesAsync();
            }
        }
    }
}
