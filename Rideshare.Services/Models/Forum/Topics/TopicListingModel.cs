namespace Rideshare.Services.Models.Forum.Topics
{
    public class TopicListingModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public string Subforum { get; set; }

        public int RepliesCount { get; set; }
    }
}
