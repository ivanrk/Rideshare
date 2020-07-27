namespace Rideshare.Services.Models.Forum.Topics
{
    using System;

    public class TopicListingModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Published { get; set; }

        public string Author { get; set; }

        public string Subforum { get; set; }

        public int RepliesCount { get; set; }

        public string LastReplyAuthor { get; set; }

        public DateTime LastReplyPublished { get; set; }
    }
}
