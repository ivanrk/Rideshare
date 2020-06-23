namespace Rideshare.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Message
    {
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime DateTime { get; set; }

        public string RecipientId { get; set; }

        public User Recipient { get; set; }

        public string SenderId { get; set; }

        public User Sender { get; set; }

        public bool IsRead { get; set; }
    }
}
