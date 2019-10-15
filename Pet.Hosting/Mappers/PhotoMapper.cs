using Pet.Hosting.Models;
using System;
using System.Linq;
using VkPhoto = Pet.Services.Models.Vk.PhotoInfo;
using FlickrPhoto = Pet.Services.Models.Flickr.PhotoInfo;

namespace Pet.Hosting.Mappers
{
    public static class PhotoMapper
    {
        private static readonly DateTime _unixOriginDate = new DateTime(1970, 1, 1, 0, 0, 0, 0);

        private static DateTime ConvertFromUnixTimestamp(long timestamp) => _unixOriginDate.AddSeconds(timestamp);

        public static Photo FromVk(VkPhoto vkPhoto)
        {
            if (vkPhoto == null)
                return null;

            var allPhotosAsc = new string[]
            {
                vkPhoto.Photo75,
                vkPhoto.Photo130,
                vkPhoto.Photo604,
                vkPhoto.Photo807,
                vkPhoto.Photo1280,
                vkPhoto.Photo2560
            }
            .Where(x => !string.IsNullOrEmpty(x))
            .ToArray();

            return new Photo
            {
                Date = ConvertFromUnixTimestamp(vkPhoto.Date),
                Description = vkPhoto.Text,
                Lat = vkPhoto.Lat,
                Long = vkPhoto.Long,
                SiteUrl = $"https://vk.com/photo{vkPhoto.OwnerId}_{vkPhoto.Id}",
                SmallPhotoUrl = allPhotosAsc.FirstOrDefault(),
                BigPhotoUrl = allPhotosAsc.LastOrDefault()
            };
        }

        public static Photo FromFlickr(FlickrPhoto flickrPhoto)
        {
            if (flickrPhoto == null)
                return null;

            var photoUrlFormat = $"https://farm{flickrPhoto.Farm}.staticflickr.com/{flickrPhoto.Server}/{flickrPhoto.Id}_{flickrPhoto.Secret}_";

            return new Photo
            {
                Description = flickrPhoto.Title,
                SiteUrl = $"https://www.flickr.com/photos/{flickrPhoto.Owner}/{flickrPhoto.Id}",
                SmallPhotoUrl = string.Format(photoUrlFormat, "t.jpg"),
                BigPhotoUrl = string.Format(photoUrlFormat, "o.jpg")
            };
        }
    }
}
