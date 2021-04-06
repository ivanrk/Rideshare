namespace Rideshare.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Rideshare.Model;
    using Rideshare.Services;
    using Rideshare.Services.Models.Users;
    using Rideshare.Web.Models.Reviews;
    using Rideshare.Web.Models.Travels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TravelsController : Controller
    {
        private readonly ITravelService travels;
        private readonly ICarService cars;
        private readonly IReviewService reviews;
        private readonly UserManager<User> userManager;

        public TravelsController(ITravelService travels, ICarService cars, IReviewService reviews,
            UserManager<User> userManager)
        {
            this.travels = travels;
            this.cars = cars;
            this.reviews = reviews;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
            => View(await this.travels.ActiveAsync());

        public async Task<IActionResult> Search(string start, string destination)
            => View(await this.travels.SearchAsync(start, destination));

        public async Task<IActionResult> Details(int id)
        {
            var userId = this.userManager.GetUserId(User);

            if (!await this.travels.ExistsAsync(id))
            {
                return NotFound();
            }

            return View(await this.travels.DetailsAsync(id, userId));
        }

        [Authorize]
        public async Task<IActionResult> Apply(int id)
        {
            var userId = this.userManager.GetUserId(User);

            await this.travels.ApplyAsync(id, userId);

            return RedirectToAction(nameof(Details), new { id });
        }

        [Authorize]
        public async Task<IActionResult> Cancel(int id)
        {
            var userId = this.userManager.GetUserId(User);

            await this.travels.CancelApplicationAsync(id, userId);

            return RedirectToAction(nameof(Details), new { id });
        }

        public async Task<IActionResult> Accept(int id, string userId)
        {
            await this.travels.AcceptAsync(id, userId);

            return RedirectToAction(nameof(Details), new { id });
        }

        public async Task<IActionResult> Reject(int id, string userId)
        {
            await this.travels.RejectAsync(id, userId);

            return RedirectToAction(nameof(Details), new { id });
        }

        public async Task<IActionResult> Rate(int id)
        {
            var userId = this.userManager.GetUserId(User);
            var travel = await this.travels.ByIdAsync(id);

            if (travel == null)
            {
                return NotFound();
            }

            var driverId = travel.DriverId;
            var passengers = travel.Passengers;

            var userIsDriver = driverId == userId;
            var userIsPassenger = passengers.Any(p => p.Id == userId);

            List<SelectListItem> ratings = SetRatingsList();
            var travelHasFinished = travel.TravelTime < DateTime.UtcNow.ToLocalTime();

            if (userIsDriver)
            {
                List<SelectListItem> passengersList = await SetPassengersList(userId, passengers);

                return View("RatePassengers", new ReviewFormViewModel
                {
                    TravelId = id,
                    Passengers = passengersList,
                    Ratings = ratings,
                    TravelHasFinished = travelHasFinished
                });
            }
            else if (userIsPassenger)
            {
                //Driver can only get 1 review from the same passenger (regardless of number of trips together)
                var hasMatch = await this.reviews.ContainsUsers(driverId, userId);

                return View("RateDriver", new ReviewFormViewModel
                {
                    TravelId = id,
                    DriverId = driverId,
                    Ratings = ratings,
                    TravelHasFinished = travelHasFinished,
                    ReviewIsAllowed = !hasMatch
                });
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Rate(ReviewFormViewModel model, string id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var authorId = this.userManager.GetUserId(User);
            var userId = model.SelectedPassenger == null ? id : model.SelectedPassenger;

            await this.reviews.CreateAsync(userId, model.SelectedRating, model.Comment, authorId);

            var user = await this.userManager.FindByIdAsync(userId);
            TempData["Success"] = $"{user.Name} was succcessfully rated.";

            return RedirectToAction(nameof(Rate), new { id = model.TravelId });
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            List<SelectListItem> cars = await SetCarsList();

            return View(new TravelFormViewModel
            {
                TravelTime = DateTime.UtcNow.Date.AddDays(1),
                Cars = cars
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(TravelFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Cars = await this.SetCarsList();
                return View(model);
            }

            var driverId = this.userManager.GetUserId(User);

            await this.travels.CreateAsync(model.StartingPoint, model.Destination, model.TravelTime, model.Price,
                model.AvailableSeats, model.AdditionalInfo, driverId, model.SelectedCar);

            return RedirectToAction(nameof(UsersController.UpcomingTravels), "Users");
        }

        private async Task<List<SelectListItem>> SetCarsList()
        {
            var userId = this.userManager.GetUserId(User);
            var availableCars = await this.cars.AllAsync(userId);

            var cars = availableCars
                .Select(c => new SelectListItem
                {
                    Text = c.Make + " " + c.Model,
                    Value = c.Id.ToString()
                })
                .ToList();

            return cars;
        }

        private async Task<List<SelectListItem>> SetPassengersList(string driverId, List<UserProfileModel> passengers)
        {
            var passengersList = new List<SelectListItem>();

            foreach (var passenger in passengers)
            {
                //Passenger can only get 1 review from the same driver (regardless of number of trips together)
                var hasMatch = await this.reviews.ContainsUsers(passenger.Id, driverId);

                if (!hasMatch)
                {
                    passengersList.Add(new SelectListItem
                    {
                        Text = passenger.Name,
                        Value = passenger.Id.ToString()
                    });
                }
            }

            return passengersList;
        }

        private static List<SelectListItem> SetRatingsList()
        {
            var grades = new List<int> { 1, 2, 3, 4, 5 };

            var ratings = grades
                .Select(r => new SelectListItem
                {
                    Text = r.ToString(),
                    Value = r.ToString()
                })
                .ToList();

            return ratings;
        }
    }
}

