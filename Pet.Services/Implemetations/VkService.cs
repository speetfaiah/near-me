using Pet.Services.Configs;
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

        public VkService(VkConfig config) : base(config)
        {
            _accessToken = config.AccessToken;
            _version = config.Version;
        }

        public async Task<BaseItemListResponse<PhotoInfo>> GetPhotosAsync(
            decimal lat, decimal @long, long offset, int count, int radius) =>
            await GetDataAsync<BaseItemListResponse<PhotoInfo>>("photos.search", 
                new ApiParam("lat", lat.ToString("")),
                new ApiParam("long", @long.ToString("")),
                new ApiParam("offset", offset),
                new ApiParam("count", count),
                new ApiParam("radius", radius),
                AccessTokenParam,
                VersionParam);

        private ApiParam AccessTokenParam => new ApiParam("access_token", _accessToken);

        private ApiParam VersionParam => new ApiParam("v", _version);
    }
}
