namespace Rideshare.Service.Models.Messages
{
    using System;

    public class MessageListingModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Sender { get; set; }

        public string Recipient { get; set; }

        public DateTime DateTime { get; set; }

        public bool IsRead { get; set; }
    }
}
