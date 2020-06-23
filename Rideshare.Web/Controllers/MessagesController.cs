namespace Rideshare.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Rideshare.Data.Models;
    using Rideshare.Services;
    using Rideshare.Services.Models.Messages;
    using System;
    using System.Threading.Tasks;

    [Authorize]
    public class MessagesController : Controller
    {
        private readonly IMessageService messages;
        private readonly UserManager<User> userManager;

        public MessagesController(IMessageService messages, UserManager<User> userManager)
        {
            this.messages = messages;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Received()
        {
            string userId = GetCurrentUserId();
            var messages = await this.messages.ReceivedAsync(userId);

            return View(messages);
        }

        public async Task<IActionResult> Sent()
        {
            string userId = GetCurrentUserId();
            var messages = await this.messages.SentAsync(userId);

            return View(messages);
        }

        public IActionResult Send(string recipient)
        {
            if (recipient == null)
            {
                return View(new MessageFormModel());
            }
            else
            {
                return View(new MessageFormModel { Recipient = recipient });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Send(MessageFormModel model)
        {
            var senderId = GetCurrentUserId();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var recipient = await this.userManager.FindByNameAsync(model.Recipient);

            if (recipient == null)
            {
                TempData["Error"] = "There is no such user. Please try again!";
                return View(model);
            }

            await this.messages.SendAsync(model.Title, model.Content, senderId, recipient.Id, DateTime.UtcNow);

            return RedirectToAction(nameof(Sent));
        }

        public async Task<IActionResult> Details(string id)
        {
            var message = await this.messages.DetailsByIdAsync(id);

            if (message.RecipientId == GetCurrentUserId())
            {
                await this.messages.MarkAsReadAsync(id);
            }
                
            return View(message);
        }

        public async Task<IActionResult> MarkAsUnread(string id)
        {
            await this.messages.MarkAsUnreadAsync(id);

            return RedirectToAction(nameof(Received));
        }

        private string GetCurrentUserId()
            => this.userManager.GetUserId(User);
    }
}
