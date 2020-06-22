namespace Rideshare.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using Rideshare.Data;
    using Rideshare.Data.Models;
    using Rideshare.Services.Models.Messages;

    public class MessageService : IMessageService
    {
        private readonly RideshareDbContext db;

        public MessageService(RideshareDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<MessageListingModel>> ReceivedAsync(string recipientId)
            => await this.db.Messages
                .Where(m => m.RecipientId == recipientId)
                .ProjectTo<MessageListingModel>()
                .ToListAsync();

        public async Task<IEnumerable<MessageListingModel>> SentAsync(string senderId)
            => await this.db.Messages
                .Where(m => m.SenderId == senderId)
                .ProjectTo<MessageListingModel>()
                .ToListAsync();

        public async Task SendAsync(string title, string content, string senderId, string recipientId, DateTime dateTime)
        {
            var message = new Message
            {
                Title = title,
                Content = content,
                SenderId = senderId,
                RecipientId = recipientId,
                DateTime = dateTime
            };

            this.db.Add(message);
            await this.db.SaveChangesAsync();
        }

        public async Task<MessageDetailsModel> DetailsByIdAsync(string id)
            => await this.db.Messages
                .Where(m => m.Id == id)
                .ProjectTo<MessageDetailsModel>()
                .FirstOrDefaultAsync();
    }
}
