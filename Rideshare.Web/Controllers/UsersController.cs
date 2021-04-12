namespace Rideshare.Web.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Rideshare.Model;
    using Rideshare.Service.Contracts;
    using System.Threading.Tasks;

    public class UsersController : Controller
    {
        private readonly IUserService users;
        private readonly UserManager<User> userManager;

        public UsersController(IUserService users, UserManager<User> userManager)
        {
            this.users = users;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Profile(string username)
        {
            if (username == null)
            {
                return NotFound();
            }

            var user = await this.userManager.FindByNameAsync(username);

            if (user == null)
            {
                return NotFound();
            }

            var profile = await this.users.ProfileAsync(user.Id);
            profile.TimesAsADriver = this.users.TimesAsADriver(user.Id);

            return View(profile);
        }

        [Route("[controller]/travels/upcoming")]
        public async Task<IActionResult> UpcomingTravels()
        {
            var userId = this.userManager.GetUserId(User);

            return View(await this.users.UpcomingTravelsAsync(userId));
        }

        [Route("[controller]/travels/history")]
        public async Task<IActionResult> TravelHistory()
        {
            var userId = this.userManager.GetUserId(User);

            return View(await this.users.TravelHistoryAsync(userId));
        }
    }
}
