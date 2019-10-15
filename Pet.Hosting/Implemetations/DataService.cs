using Pet.Hosting.Interfaces;
using Pet.Hosting.Mappers;
using Pet.Hosting.Models;
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

        public async Task<ServiceResult<PhotoList>> GetVkPhotosAsync(PhotosRequest photosRequest)
        {
            try
            {
                var offset = photosRequest.Page * photosRequest.Count;
                var vkPhotos = await _vkService.GetPhotosAsync(
                    photosRequest.Lat, 
                    photosRequest.Lon, 
                    photosRequest.Count,
                    offset,
                    photosRequest.Radius);
                return new ServiceResult<PhotoList>
                {
                    Data = new PhotoList
                    {
                        HasPhotosYet = vkPhotos.Response.Count > offset + vkPhotos.Response.Items.Count,
                        Items = vkPhotos.Response.Items
                            .Select(PhotoMapper.FromVk)
                            .ToArray()
                    }
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<PhotoList>
                {
                    Error = new ErrorMeta(ex.Message)
                };
            }
        }

        public async Task<ServiceResult<PhotoList>> GetFlickrPhotosAsync(PhotosRequest photosRequest)
        {
            try
            {
                var flickrPhotos = await _flickrService.GetPhotosAsync(
                    photosRequest.Lat,
                    photosRequest.Lon,
                    photosRequest.Page,
                    photosRequest.Count,
                    photosRequest.Radius / 1000);
                return new ServiceResult<PhotoList>
                {
                    Data = new PhotoList
                    {
                        HasPhotosYet = flickrPhotos.Photos.Page != flickrPhotos.Photos.Pages,
                        Items = flickrPhotos.Photos.Items
                            .Select(PhotoMapper.FromFlickr)
                            .ToArray()
                    }
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<PhotoList>
                {
                    Error = new ErrorMeta(ex.Message)
                };
            }
        }
    }
}
