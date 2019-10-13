using Pet.Services.Configs;
using Pet.Services.Interfaces;
using Pet.Services.Models.Base;
using System.Threading.Tasks;

namespace Pet.Services.Implemetations
{
    public class VkService : BaseApiService, IVkService
    {
        private readonly string _accessToken;

        public VkService(VkConfig config) : base(config)
        {
            _accessToken = config.AccessToken;
        }

        public async Task<ServiceResult<object>> GetPhotosAsync() =>
            await GetDataAsync<object>("photos.search", AccessTokenParam);

        private ApiParam AccessTokenParam => new ApiParam("access_token", _accessToken, UsageFlags.Query);
    }
}
