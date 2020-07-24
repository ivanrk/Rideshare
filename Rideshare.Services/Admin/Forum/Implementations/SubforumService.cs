namespace Rideshare.Services.Admin.Forum.Implementations
{
    using Microsoft.EntityFrameworkCore;
    using Rideshare.Data;
    using Rideshare.Data.Models.Forum;
    using System.Threading.Tasks;

    public class SubforumService : ISubforumService
    {
        private readonly RideshareDbContext db;

        public SubforumService(RideshareDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(string name)
        {
            var subforumExists = await this.db.Subforums.AnyAsync(sf => sf.Name == name);

            if (!subforumExists)
            {
                var subforum = new Subforum { Name = name };
                this.db.Subforums.Add(subforum);
                await this.db.SaveChangesAsync();
            }
        }
    }
}
