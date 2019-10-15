namespace Pet.Hosting.Models
{
    public class PhotosRequest
    {
        public decimal Lat { get; set; }

        public decimal Lon { get; set; }

        public int Count { get; set; }

        public int Page { get; set; } = 1;

        public int Radius { get; set; }
    }
}
