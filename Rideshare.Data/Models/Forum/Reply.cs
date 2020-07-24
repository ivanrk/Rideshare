namespace Rideshare.Data.Models.Forum
{
    using System.ComponentModel.DataAnnotations;

    public class Reply
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }

        public int TopicId { get; set; }

        public Topic Topic { get; set; }
    }
}
