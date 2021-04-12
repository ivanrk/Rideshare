namespace Rideshare.Service.Models.Forum.Subforums
{
    using System.ComponentModel.DataAnnotations;

    public class SubforumBasicModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int CategoryId { get; set; }
    }
}
