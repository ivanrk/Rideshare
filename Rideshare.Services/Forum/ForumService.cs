namespace Rideshare.Services.Forum
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using Rideshare.Data;
    using Rideshare.Services.Models.Forum;

    public class ForumService : IForumService
    {
        private readonly RideshareDbContext db;

        public ForumService(RideshareDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<CategoryListingModel>> ShowAsync()
            => await this.db.Categories
                .ProjectTo<CategoryListingModel>()
                .ToListAsync();
    }
}
