using Microsoft.AspNetCore.Mvc;
using Pet.Hosting.Interfaces;
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

        [HttpGet]
        [Route("vkphotos")]
        public async Task<JsonResult> VkPhotos(decimal lat, decimal @long, long offset, int count, int radius)
        {
            var data = await _dataService.GetVkPhotosAsync(lat, @long, offset, count, radius);
            return Json(data);
        }
    }
}
