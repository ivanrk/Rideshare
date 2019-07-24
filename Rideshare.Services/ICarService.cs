namespace Rideshare.Services
{
    using Models.Cars;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICarService
    {
        Task CreateAsync(string make, string model, string color, int year, byte[] photo, bool luggage,
            bool airConditioner, bool smoking, bool food, bool drinks, bool pets, string ownerId);

        Task<bool> EditAsync(int id, string make, string model, string color, int year, byte[] photo,
            bool luggage, bool airConditioner, bool smoking, bool food, bool drinks, bool pets, string ownerId);

        Task<bool> DeleteAsync(int id, string ownerId);

        Task<CarFormModel> ByIdAsync(int carId, string ownerId);

        Task<IEnumerable<CarListingModel>> AllAsync(string ownerId);

        Task<bool> BelongsToUser(int carId, string ownerId);
    }
}
