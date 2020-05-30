using Microsoft.AspNetCore.Mvc;
using NearMe.WebApp.Interfaces;
using NearMe.WebApp.Models;
using System.Threading.Tasks;

namespace NearMe.WebApp.Controllers
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
        public async Task<JsonResult> VkPhotos([FromBody] DataRequest dataRequest)
        {
            var data = await _dataService.GetVkPhotosAsync(dataRequest);
            return Json(data);
        }

        [HttpPost]
        [Route("flickr")]
        public async Task<JsonResult> FlickrPhotos([FromBody] DataRequest dataRequest)
        {
            var data = await _dataService.GetFlickrPhotosAsync(dataRequest);
            return Json(data);
        }
    }
}
