using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Pet.Hosting.Models;

namespace Pet.Hosting.Pages
{
    public class IndexModel : PageModel
    {
        private readonly FrontConfig _frontConfig;

        public IndexModel(IOptions<FrontConfig> options)
        {
            _frontConfig = options.Value;
        }

        public void OnGet()
        {
        }
    }
}
