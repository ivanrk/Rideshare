using AutoMapper.QueryableExtensions;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Rideshare.Data;
using Rideshare.Model;
using Rideshare.Service.Contracts;
using Rideshare.Service.Models.Cars;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Rideshare.Services.Implementations
{
    public class CarDapperService : ICarService
    {
        private readonly RideshareDbContext db;
        private readonly DbConnection connection;

        public CarDapperService(RideshareDbContext db)
        {
            this.db = db;
            connection = this.db.Database.GetDbConnection();
        }

        public async Task CreateAsync(string make, string model, string color, int year, byte[] photo, bool luggage, bool airConditioner,
            bool smoking, bool food, bool drinks, bool pets, string ownerId)
        {
            //var car = new Car
            //{
            //    Make = make,
            //    Model = model,
            //    Color = color,
            //    Year = year,
            //    HasRoomForLuggage = luggage,
            //    HasAirConditioner = airConditioner,
            //    IsSmokingAllowed = smoking,
            //    IsFoodAllowed = food,
            //    AreDrinksAllowed = drinks,
            //    ArePetsAllowed = pets,
            //    OwnerId = ownerId
            //};

            //if (photo != null)
            //{
            //    car.Photo = photo;
            //}

            //this.db.Add(car);
            //await this.db.SaveChangesAsync();

            var sql = "INSERT INTO Cars (Make, Model, Color, Year, Photo, HasRoomForLuggage, HasAirConditioner, IsSmokingAllowed, IsFoodAllowed, " +
                "AreDrinksAllowed, ArePetsAllowed, OwnerId) " +
                "VALUES (@Make, @Model, @Color, @Year, @Photo, @HasRoomForLuggage, @HasAirConditioner, @IsSmokingAllowed, @IsFoodAllowed, " +
                "@AreDrinksAllowed, @ArePetsAllowed, @OwnerId)";

            var car = await connection.ExecuteAsync(sql,
            new
            {
                Make = make,
                Model = model,
                Color = color,
                Year = year,
                Photo = photo,
                HasRoomForLuggage = luggage,
                HasAirConditioner = airConditioner,
                IsSmokingAllowed = smoking,
                IsFoodAllowed = food,
                AreDrinksAllowed = drinks,
                ArePetsAllowed = pets,
                OwnerId = ownerId,
            });
        }

        public async Task<bool> EditAsync(int id, string make, string model, string color, int year, byte[] photo,
            bool luggage, bool airConditioner, bool smoking, bool food, bool drinks, bool pets, string ownerId)
        {
            //var car = await this.db.Cars.Where(c => c.Id == id && c.OwnerId == ownerId).FirstOrDefaultAsync();
            var car = await connection.QueryFirstOrDefaultAsync<Car>("SELECT Id, OwnerId FROM Cars " +
                "WHERE Id = @id AND OwnerId = @ownerId", new { id, ownerId });

            if (car == null)
            {
                return false;
            }

            await connection.ExecuteAsync("UPDATE Cars SET Make = @make, Model = @model, Color = @color, Year = @year, " +
                "HasRoomForLuggage = @luggage, HasAirConditioner = @airConditioner, IsSmokingAllowed = @smoking, IsFoodAllowed = @food, " +
                "AreDrinksAllowed = @drinks, ArePetsAllowed = @pets WHERE Id = @id AND OwnerId = @ownerId",
                new { make, model, color, year, luggage, airConditioner, smoking, food, drinks, pets, id, ownerId });

            //car.Make = make;
            //car.Model = model;
            //car.Color = color;
            //car.Year = year;
            //car.HasRoomForLuggage = luggage;
            //car.HasAirConditioner = airConditioner;
            //car.IsSmokingAllowed = smoking;
            //car.IsFoodAllowed = food;
            //car.AreDrinksAllowed = drinks;
            //car.ArePetsAllowed = pets;

            //if (photo != null)
            //{
            //    car.Photo = photo;
            //}

            //await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id, string ownerId)
        {
            //var car = await this.db.Cars.Where(c => c.Id == id && c.OwnerId == ownerId).FirstOrDefaultAsync();
            var car = await connection.QueryFirstOrDefaultAsync<Car>("SELECT Id, OwnerId FROM Cars " +
                "WHERE Id = @id AND OwnerId = @ownerId", new { id, ownerId });

            if (car == null)
            {
                return false;
            }

            //this.db.Remove(car);
            //await this.db.SaveChangesAsync();
            await connection.ExecuteAsync("DELETE FROM Cars WHERE Id = @id AND OwnerId = @ownerId", new { id, ownerId });

            return true;
        }

        public async Task<CarFormModel> ByIdAsync(int carId, string ownerId)
        {
            var car = await connection
                .QueryFirstOrDefaultAsync<CarFormModel>("SELECT Make, Model, Color, Year, HasRoomForLuggage, HasAirConditioner, " +
                "IsSmokingAllowed, IsFoodAllowed, AreDrinksAllowed, ArePetsAllowed " +
                "FROM Cars WHERE Id = @carId AND OwnerId = @ownerId", new { carId, ownerId });

            //var car = await this.db.Cars.Where(c => c.Id == carId && c.OwnerId == ownerId).FirstOrDefaultAsync();

            if (car != null)
            {
                //return new CarFormModel
                //{
                //    Make = car.Make,
                //    Model = car.Model,
                //    Color = car.Color,
                //    Year = car.Year,
                //    HasRoomForLuggage = car.HasRoomForLuggage,
                //    HasAirConditioner = car.HasAirConditioner,
                //    IsSmokingAllowed = car.IsSmokingAllowed,
                //    IsFoodAllowed = car.IsFoodAllowed,
                //    AreDrinksAllowed = car.AreDrinksAllowed,
                //    ArePetsAllowed = car.ArePetsAllowed
                //};
                return car;
            }

            return null;
        }

        public async Task<IEnumerable<CarListingModel>> AllAsync(string ownerId)
        {
            //return await this.db
            //    .Cars
            //    .Where(c => c.OwnerId == ownerId)
            //    .ProjectTo<CarListingModel>()
            //    .ToListAsync();

            return await connection.QueryAsync<CarListingModel>("SELECT Id, Make, Model, Color, Year FROM Cars " +
                "WHERE OwnerId = @ownerId", new { ownerId });
        }

        public async Task<bool> BelongsToUser(int carId, string ownerId)
        {
            return await connection.QueryFirstOrDefaultAsync<bool>("SELECT Id, OwnerId FROM Cars " +
                "WHERE Id = @carId AND OwnerId = @ownerId", new { carId, ownerId });
            //return await this.db.Cars.AnyAsync(c => c.Id == carId && c.OwnerId == ownerId);
        }
    }
}
