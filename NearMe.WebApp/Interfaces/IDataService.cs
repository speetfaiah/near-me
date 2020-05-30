using NearMe.WebApp.Models;
using NearMe.WebApp.Models.Items;
using System.Threading.Tasks;

namespace NearMe.WebApp.Interfaces
{
    public interface IDataService
    {
        Task<ServiceResult<ItemList<Photo>>> GetVkPhotosAsync(DataRequest dataRequest);
        Task<ServiceResult<ItemList<Photo>>> GetFlickrPhotosAsync(DataRequest dataRequest);
    }
}
