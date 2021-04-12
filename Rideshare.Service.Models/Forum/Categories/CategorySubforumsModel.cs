namespace Rideshare.Service.Models.Forum.Categories
{
    using Rideshare.Service.Models.Forum.Subforums;
    using System.Collections.Generic;

    public class CategorySubforumsModel : CategoryListingModel
    {
        public List<SubforumTopicsModel> Subforums { get; set; }
    }
}
