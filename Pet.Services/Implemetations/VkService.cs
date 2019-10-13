using Pet.Services.Configs;
using Pet.Services.Interfaces;
using System;
using System.Net.Http;

namespace Pet.Services.Implemetations
{
    public class VkService : IVkService
    {
        private readonly HttpClient _httpClient;

        private readonly string _accessToken;

        public VkService(VkConfig config)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(config.BaseUrl),
                Timeout = TimeSpan.FromSeconds(config.Timeout)
            };
            _accessToken = config.AccessToken;
        }
    }
}
