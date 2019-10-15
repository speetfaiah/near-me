using Pet.Services.Configs;
using Pet.Services.Interfaces;
using Pet.Services.Models.Base;
using Pet.Services.Models.Flickr;
using System.Threading.Tasks;

namespace Pet.Services.Implemetations
{
    public class FlickrService : BaseApiService, IFlickrService
    {
        private readonly string _apiKey;

        public FlickrService(FlickrConfig config) : base(config)
        {
            _apiKey = config.ApiKey;
        }

        public async Task<PhotoSearchResponse> GetPhotosAsync(decimal lat, decimal lon, int page, int perPage, int radius) =>
            await GetDataAsync<PhotoSearchResponse>(string.Empty,
                new ApiParam("method", "flickr.photos.search"),
                new ApiParam("lat", lat),
                new ApiParam("lon", lon),
                new ApiParam("page", page),
                new ApiParam("per_page", perPage),
                new ApiParam("radius", radius),
                ApiKeyParam,
                new ApiParam("format", "json"),
                new ApiParam("nojsoncallback", 1));

        private ApiParam ApiKeyParam => new ApiParam("api_key", _apiKey);
    }
}
