using System;

namespace NearMe.WebApp.Models.Items
{
    public class Photo
    {
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
        public string SiteUrl { get; set; }
        public string SmallPhotoUrl { get; set; }
        public string BigPhotoUrl { get; set; }
    }
}
