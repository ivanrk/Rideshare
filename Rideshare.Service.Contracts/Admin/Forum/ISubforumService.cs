namespace Rideshare.Service.Contracts.Admin.Forum
{
    using Rideshare.Service.Models.Forum.Subforums;
    using Rideshare.Service.Models.Forum.Categories;
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
