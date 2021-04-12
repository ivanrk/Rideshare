namespace Rideshare.Service.Contracts.Forum
{
    using Rideshare.Service.Models.Forum.Categories;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IForumService
    {
        Task<IEnumerable<CategorySubforumsModel>> ShowAsync();
    }
}
