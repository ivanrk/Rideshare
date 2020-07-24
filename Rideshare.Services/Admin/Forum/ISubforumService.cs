namespace Rideshare.Services.Admin.Forum
{
    using Rideshare.Services.Models.Forum;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISubforumService
    {
        Task<IEnumerable<CategorySubforumsModel>> AllAsync();

        Task CreateAsync(string name, int categoryId);
    }
}
