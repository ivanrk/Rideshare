namespace Rideshare.Services.Forum
{
    using Microsoft.EntityFrameworkCore;
    using Rideshare.Data;
    using Rideshare.Data.Models.Forum;
    using AutoMapper.QueryableExtensions;
    using Rideshare.Services.Models.Forum.Topics;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TopicService : ITopicService
    {
        private readonly RideshareDbContext db;

        public TopicService(RideshareDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<TopicListingModel>> BySubforumAsync(int subforumId)
            => await this.db.Topics
                .Where(t => t.SubforumId == subforumId)
                .ProjectTo<TopicListingModel>()
                .ToListAsync();

        public async Task<TopicDetailsModel> ByIdAsync(int id)
            => await this.db.Topics
                .Where(t => t.Id == id)
                .ProjectTo<TopicDetailsModel>()
                .FirstOrDefaultAsync();

        public async Task CreateAsync(string name, string content, string authorId, int subforumId)
        {
            var topic = new Topic
            {
                Name = name,
                Content = content,
                AuthorId = authorId,
                SubforumId = subforumId
            };

            this.db.Topics.Add(topic);
            await this.db.SaveChangesAsync();
        }

        public async Task ReplyAsync(string content, string authorId, int topicId)
        {
            var reply = new Reply
            {
                Content = content,
                AuthorId = authorId,
                TopicId = topicId
            };

            this.db.Replies.Add(reply);
            await this.db.SaveChangesAsync();
        }
    }
}
