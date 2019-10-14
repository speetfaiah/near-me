using Pet.Hosting.Interfaces;
using Pet.Hosting.Models;
using Pet.Services.Helpers;
using Pet.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Pet.Hosting.Implemetations
{
    public class DataService : IDataService
    {
        private readonly IVkService _vkService;
        private readonly IFlickrService _flickrService;

        public DataService(IVkService vkService, IFlickrService flickrService)
        {
            _vkService = vkService;
            _flickrService = flickrService;
        }

        public async Task<ServiceResult<VkPhotoList>> GetVkPhotosAsync(decimal lat, decimal @long, long offset, int count, int radius)
        {
            try
            {
                var vkPhotos = await _vkService.GetPhotosAsync(lat, @long, offset, count, radius);
                var data = new VkPhotoList
                {
                    Count = vkPhotos.Response.Count,
                    Items = vkPhotos.Response.Items.Select(x => new VkPhoto
                    {
                        Date = DateTimeHelper.ConvertFromUnixTimestamp(x.Date),
                        Description = x.Text,
                        Lat = x.Lat,
                        Long = x.Long,
                        VkUrl = x.VkUrl,
                        SmallPhotoUrl = x.AllPhotosAsc.FirstOrDefault(),
                        BigPhotoUrl = x.AllPhotosAsc.LastOrDefault()
                    }).ToArray()
                };

                return new ServiceResult<VkPhotoList>
                {
                    Data = data
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<VkPhotoList>
                {
                    Error = new ErrorMeta(ex.Message)
                };
            }
        }
    }
}
