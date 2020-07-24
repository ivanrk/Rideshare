namespace Rideshare.Services.Models.Forum
{
    using Rideshare.Data.Models.Forum;
    using System.Collections.Generic;

    public class CategoryListingModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Subforum> Subforums { get; set; }
    }
}
