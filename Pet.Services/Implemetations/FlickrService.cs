using Pet.Services.Configs;
using Pet.Services.Interfaces;

namespace Pet.Services.Implemetations
{
    public class FlickrService : BaseApiService, IFlickrService
    {
        private readonly string _apiKey;
        private readonly string _version;

        public FlickrService(FlickrConfig config) : base(config)
        {
            _apiKey = config.ApiKey;
        }
    }
}
