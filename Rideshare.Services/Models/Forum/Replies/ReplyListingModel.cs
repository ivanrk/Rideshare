namespace Rideshare.Services.Models.Forum.Replies
{
    using Rideshare.Data.Models;

    public class ReplyListingModel
    {
        public string Content { get; set; }

        public User Author { get; set; }
    }
}
