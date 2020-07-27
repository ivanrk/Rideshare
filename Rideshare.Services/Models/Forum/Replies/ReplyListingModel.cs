namespace Rideshare.Services.Models.Forum.Replies
{
    using Rideshare.Services.Models.Forum.Topics;

    public class ReplyListingModel
    {
        public string Content { get; set; }

        public TopicUserModel Author { get; set; }
    }
}
