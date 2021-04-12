namespace Rideshare.Service.Models.Forum.Replies
{
    using Rideshare.Service.Models.Forum.Topics;
    using System;

    public class ReplyListingModel
    {
        public string Content { get; set; }

        public DateTime Published { get; set; }

        public TopicUserModel Author { get; set; }
    }
}
