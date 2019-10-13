using Pet.Services.Models.Vk;
using System.Threading.Tasks;

namespace Pet.Services.Interfaces
{
    public interface IVkService
    {
        Task<BaseItemListResponse<PhotoInfo>> GetPhotosAsync(decimal lat, decimal @long, long offset, int count, int radius);
    }
}
