namespace Rideshare.Service.Models.Forum.Categories
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryListingModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int SubforumsCount { get; set; }

        public int TopicsCount { get; set; }
    }
}
