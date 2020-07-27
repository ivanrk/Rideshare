namespace Rideshare.Services.Models.Forum.Replies
{
    using Rideshare.Services.Models.Forum.Topics;
    using System;

    public class ReplyListingModel
    {
        public string Content { get; set; }

        public DateTime Published { get; set; }

        public TopicUserModel Author { get; set; }
    }
}
