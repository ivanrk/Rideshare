namespace Rideshare.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using Models.Cars;
    using Rideshare.Data;
    using Rideshare.Data.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public class CarService : ICarService
    {
        private readonly RideshareDbContext db;

        public CarService(RideshareDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(string make, string model, string color, int year, byte[] photo, bool luggage,
            bool airConditioner, bool smoking, bool food, bool drinks, bool pets, string ownerId)
        {
            var car = new Car
            {
                Make = make,
                Model = model,
                Color = color,
                Year = year,
                HasRoomForLuggage = luggage,
                HasAirConditioner = airConditioner,
                IsSmokingAllowed = smoking,
                IsFoodAllowed = food,
                AreDrinksAllowed = drinks,
                ArePetsAllowed = pets,
                OwnerId = ownerId
            };

            if (photo != null)
            {
                car.Photo = photo;
            }

            this.db.Add(car);
            await this.db.SaveChangesAsync();
        }

        public async Task<bool> EditAsync(int id, string make, string model, string color, int year, byte[] photo,
            bool luggage, bool airConditioner, bool smoking, bool food, bool drinks, bool pets, string ownerId)
        {
            var car = await this.db.Cars.Where(c => c.Id == id && c.OwnerId == ownerId).FirstOrDefaultAsync();

            if (car == null)
            {
                return false;
            }

            car.Make = make;
            car.Model = model;
            car.Color = color;
            car.Year = year;
            car.HasRoomForLuggage = luggage;
            car.HasAirConditioner = airConditioner;
            car.IsSmokingAllowed = smoking;
            car.IsFoodAllowed = food;
            car.AreDrinksAllowed = drinks;
            car.ArePetsAllowed = pets;

            if (photo != null)
            {
                car.Photo = photo;
            }

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id, string ownerId)
        {
            var car = await this.db.Cars.Where(c => c.Id == id && c.OwnerId == ownerId).FirstOrDefaultAsync();

            if (car == null)
            {
                return false;
            }

            this.db.Remove(car);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<CarFormModel> ByIdAsync(int carId, string ownerId)
        {
            var car = await this.db.Cars.Where(c => c.Id == carId && c.OwnerId == ownerId).FirstOrDefaultAsync();

            if (car != null)
            {
                return new CarFormModel
                {
                    Make = car.Make,
                    Model = car.Model,
                    Color = car.Color,
                    Year = car.Year,
                    HasRoomForLuggage = car.HasRoomForLuggage,
                    HasAirConditioner = car.HasAirConditioner,
                    IsSmokingAllowed = car.IsSmokingAllowed,
                    IsFoodAllowed = car.IsFoodAllowed,
                    AreDrinksAllowed = car.AreDrinksAllowed,
                    ArePetsAllowed = car.ArePetsAllowed
                };
            }

            return null;
        }

        public async Task<IEnumerable<CarListingModel>> AllAsync(string ownerId)
            => await this.db
                .Cars
                .Where(c => c.OwnerId == ownerId)
                .ProjectTo<CarListingModel>()
                .ToListAsync();

        public async Task<bool> BelongsToUser(int carId, string ownerId)
            => await this.db.Cars.AnyAsync(c => c.Id == carId && c.OwnerId == ownerId);
    }
}
