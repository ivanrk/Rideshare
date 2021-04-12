namespace Rideshare.Service.Models.Messages
{
    using System.ComponentModel.DataAnnotations;

    public class MessageFormModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Recipient (username only)")]
        public string Recipient { get; set; }
    }
}
