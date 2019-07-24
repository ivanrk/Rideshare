namespace Rideshare.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using Rideshare.Data;
    using Rideshare.Data.Models;
    using Rideshare.Services.Models.Cars;
    using Rideshare.Services.Models.Travels;
    using Rideshare.Services.Models.Users;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TravelService : ITravelService
    {
        private readonly RideshareDbContext db;

        public TravelService(RideshareDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<TravelListingModel>> ActiveAsync()
            => await this.db
                .Travels
                .Where(t => t.TravelTime > DateTime.UtcNow.ToLocalTime() && t.Passengers.Count < t.AvailableSeats)
                .ProjectTo<TravelListingModel>()
                .OrderBy(t => t.TravelTime)
                .ToListAsync();

        public async Task<IEnumerable<TravelListingModel>> SearchAsync(string start, string destination)
        {
            if (start != null && destination != null)
            {
                return await this.db
                    .Travels
                    .Where(t => t.StartingPoint == start && t.Destination == destination)
                    .Where(t => t.TravelTime > DateTime.UtcNow.ToLocalTime() && t.Passengers.Count < t.AvailableSeats)
                    .ProjectTo<TravelListingModel>()
                    .ToListAsync();
            }
            else if (start == null)
            {
                return await this.db
                    .Travels
                    .Where(t => t.Destination == destination)
                    .Where(t => t.TravelTime > DateTime.UtcNow.ToLocalTime() && t.Passengers.Count < t.AvailableSeats)
                    .ProjectTo<TravelListingModel>()
                    .ToListAsync();
            }
            else if (destination == null)
            {
                return await this.db
                    .Travels
                    .Where(t => t.StartingPoint == start)
                    .Where(t => t.TravelTime > DateTime.UtcNow.ToLocalTime() && t.Passengers.Count < t.AvailableSeats)
                    .ProjectTo<TravelListingModel>()
                    .ToListAsync();
            }

            return null;
        }

        public async Task<TravelDetailsModel> DetailsAsync(int id, string userId)
        {
            var travel = await this.db
                .Travels
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();

            var carId = travel.CarId;
            var driverId = travel.DriverId;
            var userIsTheDriver = driverId == userId;

            TravelListingModel travelInfo = await GetTravelInfo(id);

            CarDetailsModel carInfo = await GetCarInfo(carId);

            UserProfileModel driverInfo = await GetDriverInfo(driverId);

            List<UserProfileModel> passengersInfo = await GetPassengersInfo(id);

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
            var travel = await this.db
                .Travels
                .Where(t => t.Id == id)
                .Select(t => new TravelRateModel
                {
                    DriverId = t.DriverId,
                    Passengers = t.Passengers.Select(p => new UserProfileModel
                    { Id = p.Passenger.Id, Name = p.Passenger.Name }).ToList(),
                    TravelTime = t.TravelTime
                })
                .FirstOrDefaultAsync();

            return travel;
        }

        public async Task ApplyAsync(int id, string userId)
        {
            var travel = await this.db
                .Travels
                .Where(t => t.Id == id)
                .Include(t => t.Passengers)
                .FirstOrDefaultAsync();

            if (travel.TravelTime > DateTime.UtcNow.ToLocalTime() && travel.Passengers.Count < travel.AvailableSeats && travel.DriverId != userId)
            {
                travel.Applicants.Add(new ApplicantTravel { ApplicantId = userId, TravelId = id });

                await this.db.SaveChangesAsync();
            }
        }

        public async Task CancelApplicationAsync(int id, string userId)
        {
            var application = await this.db.FindAsync<ApplicantTravel>(userId, id);

            var travelDateTime = await this.db
                .Travels
                .Where(t => t.Id == id)
                .Select(t => t.TravelTime)
                .FirstOrDefaultAsync();

            if (travelDateTime > DateTime.UtcNow.ToLocalTime())
            {
                this.db.Remove(application);

                await this.db.SaveChangesAsync();
            }
        }

        public async Task AcceptAsync(int id, string userId)
        {
            var travel = await this.db
                .Travels
                .Where(t => t.Id == id)
                .Include(t => t.Passengers)
                .Include(t => t.Applicants)
                .FirstOrDefaultAsync();

            if (travel.Passengers.Count < travel.AvailableSeats && travel.TravelTime > DateTime.UtcNow.ToLocalTime() 
                && travel.Applicants.Any(a => a.ApplicantId == userId))
            {
                travel.Passengers.Add(new PassengerTravel { PassengerId = userId, TravelId = id });

                var allUserApplications = await this.db.Users.Where(u => u.Id == userId).SelectMany(u => u.Applications).ToListAsync();
                allUserApplications.ForEach(application => this.db.Remove(application));

                if (travel.Passengers.Count == travel.AvailableSeats)
                {
                    travel.Applicants.ForEach(applicant => this.db.Remove(applicant));
                }

                await this.db.SaveChangesAsync();
            }
        }

        public async Task RejectAsync(int id, string userId)
        {
            var applicant = await this.db
                .Travels
                .Where(t => t.Id == id)
                .SelectMany(t => t.Applicants)
                .Where(a => a.ApplicantId == userId)
                .FirstOrDefaultAsync();

            this.db.Remove(applicant);

            await this.db.SaveChangesAsync();
        }

        public async Task CreateAsync(string startingPoint, string destination, DateTime travelTime, decimal price,
        int availableSeats, string additionalInfo, string driverId, int carId)
        {
            var travel = new Travel
            {
                StartingPoint = startingPoint,
                Destination = destination,
                TravelTime = travelTime,
                Price = price,
                AvailableSeats = availableSeats,
                AdditionalInfo = additionalInfo,
                DriverId = driverId,
                CarId = carId
            };

            this.db.Add(travel);
            await this.db.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
            => await this.db.Travels.AnyAsync(t => t.Id == id);

        private async Task<List<UserProfileModel>> GetApplicantsInfo(int id)
        {
            return await this.db
                .Users
                .Where(u => u.Applications.Any(a => a.TravelId == id))
                .ProjectTo<UserProfileModel>()
                .ToListAsync();
        }

        private async Task<List<UserProfileModel>> GetPassengersInfo(int id)
        {
            return await this.db
                .Users
                .Where(u => u.Travels.Any(t => t.TravelId == id))
                .ProjectTo<UserProfileModel>()
                .ToListAsync();
        }

        private async Task<UserProfileModel> GetDriverInfo(string driverId)
        {
            return await this.db
                .Users
                .Where(u => u.Id == driverId)
                .ProjectTo<UserProfileModel>()
                .FirstOrDefaultAsync();
        }

        private async Task<CarDetailsModel> GetCarInfo(int carId)
        {
            return await this.db
                .Cars
                .Where(c => c.Id == carId)
                .ProjectTo<CarDetailsModel>()
                .FirstOrDefaultAsync();
        }

        private async Task<TravelListingModel> GetTravelInfo(int id)
        {
            return await this.db
                .Travels
                .Where(t => t.Id == id)
                .ProjectTo<TravelListingModel>()
                .FirstOrDefaultAsync();
        }
    }
}
