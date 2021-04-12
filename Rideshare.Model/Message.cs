namespace Rideshare.Model
{
    using System;

    public class Message
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DateTime { get; set; }

        public string RecipientId { get; set; }

        public User Recipient { get; set; }

        public string SenderId { get; set; }

        public User Sender { get; set; }

        public bool IsRead { get; set; }

        public bool IsSent { get; set; }
    }
}
