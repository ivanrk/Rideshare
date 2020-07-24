namespace Rideshare.Services.Models.Forum
{
    using Rideshare.Data.Models.Forum;
    using System.Collections.Generic;

    public class CategorySubforumsModel : CategoryListingModel
    {
        public List<Subforum> Subforums { get; set; }
    }
}
