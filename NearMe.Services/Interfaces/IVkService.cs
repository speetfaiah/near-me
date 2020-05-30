using NearMe.Services.Models.Vk;
using System.Threading.Tasks;

namespace NearMe.Services.Interfaces
{
    public interface IVkService
    {
        Task<BaseItemListResponse<PhotoInfo>> GetPhotosAsync(decimal lat, decimal lon, int count, long offset, int radius);
    }
}
