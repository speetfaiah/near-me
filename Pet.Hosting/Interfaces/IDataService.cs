using Pet.Hosting.Models;
using System.Threading.Tasks;

namespace Pet.Hosting.Interfaces
{
    public interface IDataService
    {
        Task<ServiceResult<VkPhotoList>> GetVkPhotosAsync(decimal lat, decimal @long, long offset, int count, int radius);
    }
}
