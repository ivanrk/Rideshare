namespace Rideshare.Services.Models.Forum
{
    using Rideshare.Services.Models.Forum.Subforums;
    using System.Collections.Generic;

    public class CategorySubforumsModel : CategoryListingModel
    {
        public List<SubforumTopicsModel> Subforums { get; set; }
    }
}
