namespace Rideshare.Service.Contracts
{
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;

    public interface IPhotoService
    {
        Task<byte[]> ConvertToBytesAsync(IFormFile photo);
    }
}
