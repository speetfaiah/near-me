using Newtonsoft.Json;
using System.Linq;

namespace Pet.Services.Models.Vk
{
    public class PhotoInfo
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "owner_id")]
        public int OwnerId { get; set; }

        [JsonProperty(PropertyName = "user_id")]
        public int? UserId { get; set; }

        public string VkUrl => $"https://vk.com/photo{OwnerId}_{Id}";

        public string Text { get; set; }

        public long Date { get; set; }

        public decimal Lat { get; set; }

        public decimal Long { get; set; }

        [JsonProperty(PropertyName = "photo_75")]
        private string Photo75 { get; set; }

        [JsonProperty(PropertyName = "photo_130")]
        private string Photo130 { get; set; }

        [JsonProperty(PropertyName = "photo_604")]
        private string Photo604 { get; set; }

        [JsonProperty(PropertyName = "photo_807")]
        private string Photo807 { get; set; }

        [JsonProperty(PropertyName = "photo_1280")]
        private string Photo1280 { get; set; }

        [JsonProperty(PropertyName = "photo_2560")]
        private string Photo2560 { get; set; }

        public string[] AllPhotosAsc => new string[]
        {
            Photo75,
            Photo130,
            Photo604,
            Photo807,
            Photo1280,
            Photo2560
        }
        .Where(x => !string.IsNullOrEmpty(x))
        .ToArray();
    }

    public class PhotoSize
    {
        public string Type { get; set; }

        public string Url { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int Size => Height * Width;
    }
}
