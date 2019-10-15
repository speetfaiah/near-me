using Newtonsoft.Json;

namespace Pet.Services.Models.Vk
{
    public class PhotoInfo
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "owner_id")]
        public int OwnerId { get; set; }

        public string Text { get; set; }

        public long Date { get; set; }

        public decimal Lat { get; set; }

        public decimal Long { get; set; }

        [JsonProperty(PropertyName = "photo_75")]
        public string Photo75 { get; set; }

        [JsonProperty(PropertyName = "photo_130")]
        public string Photo130 { get; set; }

        [JsonProperty(PropertyName = "photo_604")]
        public string Photo604 { get; set; }

        [JsonProperty(PropertyName = "photo_807")]
        public string Photo807 { get; set; }

        [JsonProperty(PropertyName = "photo_1280")]
        public string Photo1280 { get; set; }

        [JsonProperty(PropertyName = "photo_2560")]
        public string Photo2560 { get; set; }
    }
}
