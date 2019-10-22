using Microsoft.AspNetCore.Mvc;
using Pet.Hosting.Interfaces;
using Pet.Hosting.Models;
using System.Threading.Tasks;

namespace Pet.Hosting.Controllers
{
    [Route("api")]
    public class DataController : Controller
    {
        private readonly IDataService _dataService;

        public DataController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpPost]
        [Route("vk")]
        public async Task<JsonResult> VkPhotos([FromBody] PhotosRequest photosRequest)
        {
            var data = await _dataService.GetVkPhotosAsync(photosRequest);
            return Json(data);
        }

        [HttpPost]
        [Route("flickr")]
        public async Task<JsonResult> FlickrPhotos([FromBody] PhotosRequest photosRequest)
        {
            var data = await _dataService.GetFlickrPhotosAsync(photosRequest);
            return Json(data);
        }
    }
}
