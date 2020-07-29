namespace Rideshare.Services.Admin.Forum
{
    using Rideshare.Services.Models.Forum;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoryService
    {
        Task<IEnumerable<CategoryListingModel>> AllAsync();

        Task<CategoryListingModel> ByIdAsync(int id);

        Task CreateAsync(string name);

        Task EditAsync(int id, string name);
    }
}
