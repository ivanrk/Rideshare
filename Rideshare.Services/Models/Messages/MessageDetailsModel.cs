namespace Rideshare.Services.Models.Messages
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class MessageDetailsModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        [Display(Name = "From")]
        public string Sender { get; set; }

        [Display(Name = "To")]
        public string Recipient { get; set; }

        public DateTime DateTime { get; set; }

        public string SenderProfilePicture { get; set; }

        public string RecipientId { get; set; }
    }
}
