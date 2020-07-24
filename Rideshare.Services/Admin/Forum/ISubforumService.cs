namespace Rideshare.Services.Admin.Forum
{
    using System.Threading.Tasks;

    public interface ISubforumService
    {
        Task CreateAsync(string name);
    }
}
