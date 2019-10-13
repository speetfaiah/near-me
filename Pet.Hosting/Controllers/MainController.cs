using Microsoft.AspNetCore.Mvc;
using Pet.Hosting.Interfaces;
using System.Threading.Tasks;

namespace Pet.Hosting.Controllers
{
    public class MainController : Controller
    {
        private readonly IDataService _dataService;

        public MainController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public ViewResult Index() => View();

        [HttpGet]
        public async Task<JsonResult> VkPhotos(decimal lat, decimal @long, long offset, int count, int radius)
        {
            var data = await _dataService.GetVkPhotosAsync(lat, @long, offset, count, radius);
            return Json(data);
        }
    }
}
