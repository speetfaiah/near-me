using Pet.Hosting.Models;
using System.Threading.Tasks;

namespace Pet.Hosting.Interfaces
{
    public interface IDataService
    {
        Task<ServiceResult<PhotoList>> GetVkPhotosAsync(PhotosRequest photosRequest);
        Task<ServiceResult<PhotoList>> GetFlickrPhotosAsync(PhotosRequest photosRequest);
    }
}
