using System.Net.Http;

namespace Pet.VkApi.Services
{
    public abstract class BaseService
    {
        protected readonly HttpClient _httpClient;

        public BaseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
