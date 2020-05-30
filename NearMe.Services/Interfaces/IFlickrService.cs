using NearMe.Services.Models.Flickr;
using System.Threading.Tasks;

namespace NearMe.Services.Interfaces
{
    public interface IFlickrService
    {
        Task<PhotoSearchResponse> GetPhotosAsync(decimal lat, decimal lon, int page, int perPage, int radius);
    }
}
