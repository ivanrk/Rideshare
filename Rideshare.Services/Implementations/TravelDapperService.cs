namespace Rideshare.Services.Implementations
{
    using Dapper;
    using Microsoft.EntityFrameworkCore;
    using Rideshare.Data;
    using Rideshare.Model;
    using Rideshare.Service.Contracts;
    using Rideshare.Service.Models.Cars;
    using Rideshare.Service.Models.Travels;
    using Rideshare.Service.Models.Users;
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Linq;
    using System.Threading.Tasks;

    public class TravelDapperService : ITravelService
    {
        private readonly RideshareDbContext db;
        private readonly DbConnection connection;

        public TravelDapperService(RideshareDbContext db)
        {
            this.db = db;
            connection = this.db.Database.GetDbConnection();
        }

        public async Task<IEnumerable<TravelListingModel>> ActiveAsync()
        {
            var travels = await connection
                .QueryAsync<TravelListingModel>("SELECT * FROM Travels WHERE TravelTime > GETUTCDATE() AND " +
                "(SELECT COUNT(PassengerId) FROM PassengerTravel WHERE TravelId = Id) < AvailableSeats ORDER BY TravelTime");

            foreach (var travel in travels)
            {
                await SetTravelInfo(travel);
            }

            return travels;
        }

        public async Task<IEnumerable<TravelListingModel>> SearchAsync(string start, string destination)
        {
            IEnumerable<TravelListingModel> travels = new List<TravelListingModel>();

            if (start != null && destination != null)
            {
                travels = await connection
                    .QueryAsync<TravelListingModel>("SELECT * FROM Travels " +
                    "WHERE StartingPoint = @start AND Destination = @destination AND TravelTime > @currentDateTime AND " +
                    "(SELECT COUNT(PassengerId) FROM PassengerTravel WHERE TravelId = Id) < AvailableSeats",
                    new { start, destination, currentDateTime = DateTime.UtcNow });
            }
            else if (start == null)
            {
                travels = await connection
                    .QueryAsync<TravelListingModel>("SELECT * FROM Travels " +
                    "WHERE Destination = @destination AND TravelTime > @currentDateTime AND " +
                    "(SELECT COUNT(PassengerId) FROM PassengerTravel WHERE TravelId = Id) < AvailableSeats",
                    new { start, destination, currentDateTime = DateTime.UtcNow });
            }
            else if (destination == null)
            {
                travels = await connection
                    .QueryAsync<TravelListingModel>("SELECT * FROM Travels " +
                    "WHERE StartingPoint = @start AND TravelTime > @currentDateTime AND " +
                    "(SELECT COUNT(PassengerId) FROM PassengerTravel WHERE TravelId = Id) < AvailableSeats",
                    new { start, destination, currentDateTime = DateTime.UtcNow });
            }

            foreach (var travel in travels)
            {
                await SetTravelInfo(travel);
            }

            return travels;
        }

        public async Task<TravelDetailsModel> DetailsAsync(int id, string userId)
        {
            var travel = await connection.QueryFirstOrDefaultAsync<Travel>("SELECT CarId, DriverId FROM Travels WHERE Id = @id",
                new { Id = id });

            var carId = travel.CarId;
            var driverId = travel.DriverId;
            var userIsTheDriver = driverId == userId;

            TravelListingModel travelInfo = await GetTravelInfo(id);

            CarDetailsModel carInfo = await GetCarInfo(carId);

            UserProfileModel driverInfo = await GetUserInfo(driverId);

            List<UserProfileModel> passengersInfo = await SetPassengersToTravel(id);

            var userIsInTravel = passengersInfo.Any(p => p.Id == userId);

            List<UserProfileModel> applicantsInfo = await GetApplicantsInfo(id);

            var userHasApplied = applicantsInfo.Any(a => a.Id == userId);

            return new TravelDetailsModel
            {
                Travel = travelInfo,
                Car = carInfo,
                Driver = driverInfo,
                UserIsInTravel = userIsInTravel,
                UserIsTheDriver = userIsTheDriver,
                UserHasApplied = userHasApplied,
                Passengers = passengersInfo,
                Applicants = applicantsInfo
            };
        }

        public async Task<TravelRateModel> ByIdAsync(int id)
        {
            var travel = await connection
                .QueryFirstOrDefaultAsync<TravelRateModel>("SELECT DriverId, TravelTime FROM Travels WHERE Id = @id", new { id });

            travel.Passengers = await SetPassengersToTravel(id);

            return travel;
        }

        private async Task<List<UserProfileModel>> SetPassengersToTravel(int id)
        {
            var passengers = new List<UserProfileModel>();

            var passengerIds = await connection
                .QueryAsync<string>("SELECT PassengerId FROM PassengerTravel WHERE TravelId = @id", new { id });

            foreach (var passengerId in passengerIds)
            {
                UserProfileModel passenger = await GetUserInfo(passengerId);

                passengers.Add(passenger);
            }

            return passengers;
        }

        private async Task<UserProfileModel> GetUserInfo(string userId)
        {
            var user = await connection
                .QueryFirstOrDefaultAsync<UserProfileModel>("SELECT Id, Username, Name, PhoneNumber FROM AspNetUsers " +
                "WHERE Id = @userId", new { userId });

            var profilePicture = await connection
                .QueryFirstOrDefaultAsync<byte[]>("SELECT ProfilePicture FROM AspNetUsers " +
                "WHERE Id = @userId", new { userId });

            if (profilePicture != null)
            {
                user.ProfilePicture = String.Format("data:image/png;base64,{0}", Convert.ToBase64String(profilePicture));
            }
            else
            {
                user.ProfilePicture = null;
            }

            return user;
        }

        public async Task ApplyAsync(int id, string userId)
        {
            var travel = await connection
                .QueryFirstOrDefaultAsync<Travel>("SELECT Id, TravelTime, AvailableSeats, DriverId FROM Travels WHERE Id = @id", new { id });

            var passengersCount = await connection
                .QueryFirstOrDefaultAsync<int>("SELECT COUNT(PassengerId) FROM PassengerTravel WHERE TravelId = @id", new { id });

            if (travel.TravelTime > DateTime.UtcNow && passengersCount < travel.AvailableSeats && travel.DriverId != userId)
            {
                await connection.ExecuteAsync("INSERT INTO ApplicantTravel (ApplicantId, TravelId) VALUES (@userId, @id)", new { userId, id });
            }
        }

        public async Task CancelApplicationAsync(int id, string userId)
        {
            var application = await connection
                .QueryFirstOrDefaultAsync<ApplicantTravel>("SELECT * FROM ApplicantTravel WHERE ApplicantId = @userId AND TravelId = @id",
                new { userId, id });

            var travelDateTime = await connection
                .QueryFirstOrDefaultAsync<DateTime>("SELECT TravelTime FROM Travels WHERE Id = @id", new { id });

            if (travelDateTime > DateTime.UtcNow)//.ToLocalTime())
            {
                await connection
                    .ExecuteAsync("DELETE FROM ApplicantTravel WHERE ApplicantId = @userId AND TravelId = @id", new { userId, id });
            }
        }

        public async Task AcceptAsync(int id, string userId)
        {
            var travel = await connection
                .QueryFirstOrDefaultAsync<Travel>("SELECT Id, TravelTime, AvailableSeats FROM Travels WHERE Id = @id", new { id });

            var passengersCount = await connection
                .QueryFirstOrDefaultAsync<int>("SELECT COUNT(PassengerId) FROM PassengerTravel WHERE TravelId = @id", new { id });

            var applicantExists = await connection
                .QueryFirstOrDefaultAsync<bool>("SELECT 1 FROM ApplicantTravel WHERE ApplicantId = @userId AND TravelId = @id",
                new { userId, id });

            if (passengersCount < travel.AvailableSeats && travel.TravelTime > DateTime.UtcNow && applicantExists)
            {
                passengersCount++;
                await connection.ExecuteAsync("INSERT INTO PassengerTravel (PassengerId, TravelId) VALUES (@userId, @id)", new { userId, id });
                await connection.ExecuteAsync("DELETE FROM ApplicantTravel WHERE ApplicantId = @userId", new { userId });

                if (passengersCount == travel.AvailableSeats)
                {
                    await connection.ExecuteAsync("DELETE FROM ApplicantTravel WHERE TravelId = @id", new { id });
                }
            }
        }

        public async Task RejectAsync(int id, string userId)
        {
            await connection
                .ExecuteAsync("DELETE FROM ApplicantTravel WHERE TravelId = @id AND ApplicantId = @userId", new { id, userId });
        }

        public async Task CreateAsync(string startingPoint, string destination, DateTime travelTime, decimal price,
        int availableSeats, string additionalInfo, string driverId, int carId)
        {
            var sql = "INSERT INTO Travels (StartingPoint, Destination, TravelTime, Price, AvailableSeats, AdditionalInfo, DriverId, CarId)" +
                " VALUES (@StartingPoint, @Destination, @TravelTime, @Price, @AvailableSeats, @AdditionalInfo, @DriverId, @CarId)";

            var travel = await connection.ExecuteAsync(sql, new
            {
                StartingPoint = startingPoint,
                Destination = destination,
                TravelTime = travelTime,
                Price = price,
                AvailableSeats = availableSeats,
                AdditionalInfo = additionalInfo,
                DriverId = driverId,
                CarId = carId
            });
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await connection.QueryFirstOrDefaultAsync<bool>("SELECT Id FROM Travels WHERE Id = @id", new { id });
        }

        private async Task<List<UserProfileModel>> GetApplicantsInfo(int id)
        {
            var applicants = new List<UserProfileModel>();
            var applicantIds = await connection.QueryAsync<string>("SELECT ApplicantId FROM ApplicantTravel WHERE TravelId = @id", new { id });

            foreach (var applicantId in applicantIds)
            {
                var applicant = await GetUserInfo(applicantId);
                applicants.Add(applicant);
            }

            return applicants;
        }

        private async Task<CarDetailsModel> GetCarInfo(int carId)
        {
            var car = await connection
                .QueryFirstOrDefaultAsync<CarDetailsModel>("SELECT Make, Model, Color, Year, HasRoomForLuggage, HasAirConditioner, " +
                "IsSmokingAllowed, IsFoodAllowed, AreDrinksAllowed, ArePetsAllowed, OwnerId FROM Cars WHERE Id = @carId", new { carId });

            var photo = await connection.QueryFirstOrDefaultAsync<byte[]>("SELECT Photo FROM Cars WHERE Id = @carId", new { carId });

            if (photo != null)
            {
                car.Photo = String.Format("data:image/png;base64,{0}", Convert.ToBase64String(photo));
            }
            else
            {
                car.Photo = null;
            }

            return car;
        }

        private async Task<TravelListingModel> GetTravelInfo(int id)
        {
            var travel = await connection
                .QueryFirstOrDefaultAsync<TravelListingModel>("SELECT Id, StartingPoint, Destination, TravelTime, Price, AvailableSeats, " +
                "AdditionalInfo FROM Travels WHERE Id = @id", new { id });

            await SetTravelInfo(travel);

            return travel;
        }

        private async Task SetTravelInfo(TravelListingModel travel)
        {
            var carId = await connection.QueryFirstOrDefaultAsync<int>("SELECT CarId FROM Travels WHERE Id = @id", new { id = travel.Id });
            var driverId = await connection.QueryFirstOrDefaultAsync<string>("SELECT DriverId FROM Travels WHERE Id = @id", new { id = travel.Id });

            travel.Car = await connection
                .QueryFirstOrDefaultAsync<string>("SELECT Make + ' ' + Model FROM Cars WHERE Id = @carId", new { carId });

            var driver = await connection
                .QueryFirstOrDefaultAsync<UserBasicProfileModel>("SELECT Username, Name FROM AspNetUsers WHERE Id = @driverId",
                new { driverId });

            var profilePicture = await connection
                .QueryFirstOrDefaultAsync<byte[]>("SELECT ProfilePicture FROM AspNetUsers WHERE Id = @driverId", new { driverId });

            if (profilePicture != null)
            {
                driver.ProfilePicture = String.Format("data:image/png;base64,{0}", Convert.ToBase64String(profilePicture));
            }
            else
            {
                driver.ProfilePicture = null;
            }

            travel.Driver = driver;

            travel.Passengers = await connection
                .QueryFirstOrDefaultAsync<int>("SELECT COUNT(PassengerId) FROM PassengerTravel WHERE TravelId = @id",
                new { id = travel.Id });
        }
    }
}
