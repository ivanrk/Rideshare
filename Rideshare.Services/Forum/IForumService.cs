namespace Rideshare.Services.Forum
{
    using Rideshare.Services.Models.Forum;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IForumService
    {
        Task<IEnumerable<CategoryListingModel>> ShowAsync();
    }
}
