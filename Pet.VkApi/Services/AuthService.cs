using Pet.VkApi.Interfaces;
using System.Net.Http;

namespace Pet.VkApi.Services
{
    public class AuthService : BaseService, IAuthService
    {
        public AuthService(HttpClient httpClient) : base(httpClient) { }
    }
}
