namespace Rideshare.Web.Areas.Forum.Models.Topics
{
    using System.ComponentModel.DataAnnotations;

    public class TopicFormViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public int SubforumId { get; set; }
    }
}
