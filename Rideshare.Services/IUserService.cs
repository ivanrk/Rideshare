namespace Rideshare.Services
{
    using Rideshare.Services.Models.Travels;
    using Rideshare.Services.Models.Users;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task<UserDetailsModel> ProfileAsync(string id);

        Task<IEnumerable<UserTravelListingModel>> UpcomingTravelsAsync(string userId);

        Task<IEnumerable<TravelBasicModel>> TravelHistoryAsync(string id);

        Task<string> GetProfilePictureAsync(string userId);

        Task SetProfilePictureAsync(string userId, byte[] profilePicture);

        int TimesAsADriver(string userId);
    }
}
