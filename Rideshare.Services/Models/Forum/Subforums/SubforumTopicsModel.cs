namespace Rideshare.Services.Models.Forum.Subforums
{
    using Rideshare.Services.Models.Forum.Topics;
    using System.Collections.Generic;

    public class SubforumTopicsModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<TopicListingModel> Topics { get; set; }
    }
}
