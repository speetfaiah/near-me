﻿using NearMe.Services.Interfaces;
using NearMe.Services.Models.Base;
using NearMe.Services.Models.Vk;
using System.Threading.Tasks;

namespace NearMe.Services.Implemetations
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

        public Task<BaseItemListResponse<PhotoInfo>> GetPhotosAsync(decimal lat, decimal lon, int count, long offset, int radius)
            => GetDataAsync<BaseItemListResponse<PhotoInfo>>("photos.search",
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
