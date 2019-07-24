namespace Rideshare.Services
{
    using Rideshare.Services.Models.Travels;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITravelService
    {
        Task<IEnumerable<TravelListingModel>> ActiveAsync();

        Task<IEnumerable<TravelListingModel>> SearchAsync(string start, string destination);

        Task<TravelDetailsModel> DetailsAsync(int id, string userId);

        Task<TravelRateModel> ByIdAsync(int id);

        Task ApplyAsync(int id, string userId);

        Task CancelApplicationAsync(int id, string userId);

        Task AcceptAsync(int id, string userId);

        Task RejectAsync(int id, string userId);

        Task CreateAsync(string startingPoint, string destination, DateTime travelTime, decimal price, 
            int availableSeats, string additionalInfo, string driverId, int carId);

        Task<bool> ExistsAsync(int id);
    }
}
