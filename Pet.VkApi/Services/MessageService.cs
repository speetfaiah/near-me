using Pet.VkApi.Interfaces;
using System.Net.Http;

namespace Pet.VkApi.Services
{
    public class MessageService : BaseService, IMessageService
    {
        public MessageService(HttpClient httpClient) : base(httpClient) { }
    }
}
