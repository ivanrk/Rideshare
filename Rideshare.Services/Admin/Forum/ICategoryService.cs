namespace Rideshare.Services.Admin.Forum
{
    using Rideshare.Services.Models.Forum;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoryService
    {
        Task<IEnumerable<CategoryListingModel>> AllAsync();

        Task CreateAsync(string name);
    }
}
