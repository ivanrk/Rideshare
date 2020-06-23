namespace Rideshare.Services
{
    using Rideshare.Services.Models.Messages;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMessageService
    {
        Task<IEnumerable<MessageListingModel>> ReceivedAsync(string recipientId);

        Task<IEnumerable<MessageListingModel>> SentAsync(string senderId);

        Task SendAsync(string title, string content, string senderId, string recipientId, DateTime dateTime);

        Task<MessageDetailsModel> DetailsByIdAsync(string id);

        Task MarkAsReadAsync(string id);

        Task MarkAsUnreadAsync(string id);
    }
}
