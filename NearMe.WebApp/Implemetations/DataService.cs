using NearMe.WebApp.Interfaces;
using NearMe.WebApp.Mappers;
using NearMe.WebApp.Models;
using NearMe.WebApp.Models.Items;
using NearMe.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NearMe.WebApp.Implemetations
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

        public async Task<ServiceResult<ItemList<Photo>>> GetVkPhotosAsync(DataRequest dataRequest)
        {
            try
            {
                var offset = dataRequest.Page * dataRequest.Count;
                var vkPhotos = await _vkService.GetPhotosAsync(
                    dataRequest.Lat,
                    dataRequest.Lon,
                    dataRequest.Count,
                    offset,
                    dataRequest.Radius);
                return new ServiceResult<ItemList<Photo>>
                {
                    Data = new ItemList<Photo>
                    {
                        HasMore = vkPhotos.Response.Count > offset + vkPhotos.Response.Items.Count,
                        Items = vkPhotos.Response.Items
                            .Select(PhotoMapper.FromVk)
                            .ToArray()
                    }
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<ItemList<Photo>>
                {
                    Error = new ErrorMeta(ex.Message)
                };
            }
        }

        public async Task<ServiceResult<ItemList<Photo>>> GetFlickrPhotosAsync(DataRequest dataRequest)
        {
            try
            {
                var flickrPhotos = await _flickrService.GetPhotosAsync(
                    dataRequest.Lat,
                    dataRequest.Lon,
                    dataRequest.Page,
                    dataRequest.Count,
                    dataRequest.Radius / 1000);
                return new ServiceResult<ItemList<Photo>>
                {
                    Data = new ItemList<Photo>
                    {
                        HasMore = flickrPhotos.Photos.Page != flickrPhotos.Photos.Pages,
                        Items = flickrPhotos.Photos.Items
                            .Select(PhotoMapper.FromFlickr)
                            .ToArray()
                    }
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<ItemList<Photo>>
                {
                    Error = new ErrorMeta(ex.Message)
                };
            }
        }
    }
}
