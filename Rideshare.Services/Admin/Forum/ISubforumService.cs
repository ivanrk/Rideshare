namespace Rideshare.Services.Admin.Forum
{
    using Rideshare.Services.Models.Forum;
    using Rideshare.Services.Models.Forum.Subforums;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISubforumService
    {
        Task<IEnumerable<CategorySubforumsModel>> AllAsync();

        Task<SubforumBasicModel> ByIdAsync(int id);

        Task CreateAsync(string name, int categoryId);

        Task EditAsync(int id, string name, int categoryId);

        Task<bool> Exists(int id);
    }
}
