namespace Rideshare.Web.Areas.Forum.Models.Topics
{
    using Rideshare.Service.Models.Forum.Topics;
    using System.Collections.Generic;

    public class TopicListingViewModel
    {
        public int SubforumId { get; set; }

        public IEnumerable<TopicListingModel> Topics { get; set; }
    }
}
