namespace Rideshare.Services.Implementations
{
    using Microsoft.AspNetCore.Http;
    using Rideshare.Service.Contracts;
    using System.IO;
    using System.Threading.Tasks;

    public class PhotoService : IPhotoService
    {
        private readonly MemoryStream memoryStream;

        public PhotoService()
        {
            this.memoryStream = new MemoryStream();
        }

        public async Task<byte[]> ConvertToBytesAsync(IFormFile photo)
        {
            if (photo != null)
            {
                using (memoryStream)
                {
                    await photo.CopyToAsync(memoryStream);

                    return memoryStream.ToArray();
                }
            }

            return null;
        }
    }
}
