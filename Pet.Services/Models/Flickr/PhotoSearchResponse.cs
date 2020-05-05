using Newtonsoft.Json;
using System.Collections.Generic;

namespace Pet.Services.Models.Flickr
{
    public class PhotoSearchResponse
    {
        public PhotoList Photos { get; set; }
    }

    public class PhotoList
    {
        public int Page { get; set; }
        public int Pages { get; set; }
        public long Total { get; set; }
        [JsonProperty(PropertyName = "photo")]
        public List<PhotoInfo> Items { get; set; }
    }
}
