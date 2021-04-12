namespace Rideshare.Services.Forum
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using Rideshare.Data;
    using Rideshare.Service.Contracts.Forum;
    using Rideshare.Service.Models.Forum.Categories;

    public class ForumService : IForumService
    {
        private readonly RideshareDbContext db;

        public ForumService(RideshareDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<CategorySubforumsModel>> ShowAsync()
            => await this.db.Categories
                .ProjectTo<CategorySubforumsModel>()
                .ToListAsync();
    }
}
