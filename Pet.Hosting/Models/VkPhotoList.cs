using System;

namespace Pet.Hosting.Models
{
    public class VkPhotoList
    {
        public long Count { get; set; }

        public VkPhoto[] Items { get; set; }

        public static VkPhotoList Empty =>
            new VkPhotoList
            {
                Count = 0,
                Items = Array.Empty<VkPhoto>()
            };
    }

    public class VkPhoto
    {
        public string Description { get; set; }

        public DateTime Date { get; set; }

        public decimal Lat { get; set; }

        public decimal Long { get; set; }

        public string VkUrl { get; set; }

        public string SmallPhotoUrl { get; set; }

        public string BigPhotoUrl { get; set; }
    }
}
