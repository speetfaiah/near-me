using Pet.Hosting.Models;
using Pet.Hosting.Models.Items;
using System.Threading.Tasks;

namespace Pet.Hosting.Interfaces
{
    public interface IDataService
    {
        Task<ServiceResult<ItemList<Photo>>> GetVkPhotosAsync(DataRequest dataRequest);
        Task<ServiceResult<ItemList<Photo>>> GetFlickrPhotosAsync(DataRequest dataRequest);
    }
}
