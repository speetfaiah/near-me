using Microsoft.Extensions.Options;
using Pet.Services.Interfaces;
using Pet.Services.Models.Base;
using Pet.Services.Models.Vk;
using System.Threading.Tasks;

namespace Pet.Services.Implemetations
{
    public class VkService : BaseApiService, IVkService
    {
        private readonly string _accessToken;
        private readonly string _version;

        public VkService(IOptions<VkConfig> options) : base(options.Value)
        {
            _accessToken = options.Value.AccessToken;
            _version = options.Value.Version;
        }

        public async Task<BaseItemListResponse<PhotoInfo>> GetPhotosAsync(decimal lat, decimal lon, int count, long offset, int radius) =>
            await GetDataAsync<BaseItemListResponse<PhotoInfo>>("photos.search", 
                new ApiParam("lat", lat),
                new ApiParam("long", lon),
                new ApiParam("offset", offset),
                new ApiParam("count", count),
                new ApiParam("radius", radius),
                AccessTokenParam,
                VersionParam);

        private ApiParam AccessTokenParam => new ApiParam("access_token", _accessToken);

        private ApiParam VersionParam => new ApiParam("v", _version);
    }
}
