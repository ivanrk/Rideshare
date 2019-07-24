namespace Rideshare.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using Rideshare.Data;
    using Rideshare.Services.Models.Travels;
    using Rideshare.Services.Models.Users;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly RideshareDbContext db;

        public UserService(RideshareDbContext db)
        {
            this.db = db;
        }

        public async Task<UserDetailsModel> ProfileAsync(string id)
            => await this.db
                .Users
                .Where(u => u.Id == id)
                .ProjectTo<UserDetailsModel>()
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<UserTravelListingModel>> UpcomingTravelsAsync(string userId)
            => await this.db.Travels
                .Where(t => t.TravelTime > DateTime.UtcNow.ToLocalTime())
                .Where(t => t.Passengers.Any(p => p.PassengerId == userId) ||
                                    t.DriverId == userId)
                .ProjectTo<UserTravelListingModel>(new { userId })
                .ToListAsync();

        public async Task<IEnumerable<TravelBasicModel>> TravelHistoryAsync(string userId)
            => await this.db
                .Travels
                .Where(t => t.TravelTime < DateTime.UtcNow.ToLocalTime())
                .Where(t => t.Passengers.Any(p => p.PassengerId == userId) ||
                        (t.DriverId == userId && t.Passengers.Any()))
                .OrderByDescending(t => t.TravelTime)
                .ProjectTo<TravelBasicModel>()
                .ToListAsync();

        public async Task<string> GetProfilePictureAsync(string userId)
        {
            var user = await this.db.Users.FirstOrDefaultAsync(u => u.Id == userId);
            var profilePicture = user.ProfilePicture;

            if (profilePicture != null)
            {
                return String.Format("data:image/png;base64,{0}", Convert.ToBase64String(profilePicture));
            }

            return null;
        }

        public async Task SetProfilePictureAsync(string userId, byte[] profilePicture)
        {
            var user = await this.db.Users.FirstOrDefaultAsync(u => u.Id == userId);

            user.ProfilePicture = profilePicture;
            
            await this.db.SaveChangesAsync();
        }

        public int TimesAsADriver(string userId)
            => this.db.Travels.Where(t => t.DriverId == userId && t.Passengers.Count > 0).Count();
    }
}
