using System;

namespace Pet.Hosting.Models
{
    public class PhotoList
    {
        public bool HasPhotosYet { get; set; }

        public Photo[] Items { get; set; }
    }

    public class Photo
    {
        public string Description { get; set; }

        public DateTime? Date { get; set; }

        public decimal Lat { get; set; }

        public decimal Long { get; set; }

        public string SiteUrl { get; set; }

        public string SmallPhotoUrl { get; set; }

        public string BigPhotoUrl { get; set; }
    }
}
