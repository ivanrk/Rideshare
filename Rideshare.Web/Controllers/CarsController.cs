namespace Rideshare.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Rideshare.Data.Models;
    using Rideshare.Services;
    using Rideshare.Services.Models.Cars;
    using System.Threading.Tasks;

    [Authorize]
    public class CarsController : Controller
    {
        private readonly ICarService cars;
        private readonly IPhotoService photos;
        private UserManager<User> userManager;

        public CarsController(ICarService cars, IPhotoService photos, UserManager<User> userManager)
        {
            this.cars = cars;
            this.photos = photos;
            this.userManager = userManager;
        }

        public IActionResult Create()
            => View(new CarFormModel());

        [HttpPost]
        public async Task<IActionResult> Create(CarFormModel carModel)
        {
            if (!ModelState.IsValid)
            {
                return View(carModel);
            }

            var userId = this.userManager.GetUserId(User);

            byte[] photo = await this.photos.ConvertToBytesAsync(carModel.Photo);

            await this.cars.CreateAsync(carModel.Make, carModel.Model, carModel.Color, carModel.Year, photo,
                carModel.HasRoomForLuggage, carModel.HasAirConditioner, carModel.IsSmokingAllowed, 
                carModel.IsFoodAllowed, carModel.AreDrinksAllowed, carModel.ArePetsAllowed, userId);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var ownerId = this.userManager.GetUserId(User);
            var car = await this.cars.ByIdAsync(id, ownerId);

            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CarFormModel carModel)
        {
            if (!ModelState.IsValid)
            {
                return View(carModel);
            }

            var ownerId = this.userManager.GetUserId(User);

            byte[] photo = await this.photos.ConvertToBytesAsync(carModel.Photo);

            var success = await this.cars.EditAsync(id, carModel.Make, carModel.Model, carModel.Color,
                carModel.Year, photo, carModel.HasRoomForLuggage, carModel.HasAirConditioner, carModel.IsSmokingAllowed, 
                carModel.IsFoodAllowed, carModel.AreDrinksAllowed, carModel.ArePetsAllowed, ownerId);

            if (!success)
            {
                return BadRequest();
            }

            TempData["Success"] = "Changes were saved successfully.";
            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var ownerId = this.userManager.GetUserId(User);

            if (!await this.cars.BelongsToUser(id, ownerId))
            {
                return BadRequest();
            }

            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var ownerId = this.userManager.GetUserId(User);

            var success = await this.cars.DeleteAsync(id, ownerId);

            if (!success)
            {
                return BadRequest();
            }

            TempData["Success"] = "Your car was deleted successfully.";
            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> All()
        {
            var userId = this.userManager.GetUserId(User);

            return View(await this.cars.AllAsync(userId));
        }
    }
}
