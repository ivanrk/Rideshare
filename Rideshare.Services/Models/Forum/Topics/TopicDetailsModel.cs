namespace Rideshare.Services.Models.Forum.Topics
{
    using Rideshare.Services.Models.Forum.Replies;
    using System.Collections.Generic;

    public class TopicDetailsModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public TopicUserModel Author { get; set; }

        public List<ReplyListingModel> Replies { get; set; }
    }
}
