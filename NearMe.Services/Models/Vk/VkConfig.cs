using NearMe.Services.Models.Base;

namespace NearMe.Services.Models.Vk
{
    public class VkConfig : BaseApiConfig
    {
        public string AccessToken { get; set; }
        public string Version { get; set; }
    }
}
