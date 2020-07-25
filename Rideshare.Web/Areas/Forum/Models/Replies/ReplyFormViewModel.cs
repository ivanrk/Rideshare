namespace Rideshare.Web.Areas.Forum.Models.Replies
{
    using System.ComponentModel.DataAnnotations;

    public class ReplyFormViewModel
    {
        [Required]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public int TopicId { get; set; }
    }
}
