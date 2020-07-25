namespace Rideshare.Services.Models.Forum.Subforums
{
    using Rideshare.Data.Models.Forum;
    using System.Collections.Generic;

    public class SubforumTopicsModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Topic> Topics { get; set; }
    }
}
