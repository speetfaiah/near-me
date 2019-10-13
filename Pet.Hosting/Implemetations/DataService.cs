using Pet.Hosting.Interfaces;
using Pet.Services.Interfaces;

namespace Pet.Hosting.Implemetations
{
    public class DataService : IDataService
    {
        private readonly IVkService _vkService;

        public DataService(IVkService vkService)
        {
            _vkService = vkService;
        }
    }
}
