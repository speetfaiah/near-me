using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NearMe.WebApp.Interfaces;
using NearMe.WebApp.Implemetations;
using NearMe.Services.Implemetations;
using NearMe.Services.Interfaces;
using NearMe.WebApp.Models;
using NearMe.Services.Models.Vk;
using NearMe.Services.Models.Flickr;

namespace NearMe.WebApp
{
    public class Startup
    {
        private readonly IConfigurationRoot _configuration;

        public Startup(IHostingEnvironment env)
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json")
                .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<FrontConfig>(_configuration.GetSection("frontConfig"));

            var vkConfig = new VkConfig();
            _configuration.GetSection("vkConfig").Bind(vkConfig);
            services.AddSingleton<IVkService, VkService>(x => new VkService(vkConfig));

            var flickrConfig = new FlickrConfig();
            _configuration.GetSection("flickrConfig").Bind(flickrConfig);
            services.AddSingleton<IFlickrService, FlickrService>(x => new FlickrService(flickrConfig));

            services.AddSingleton<IDataService, DataService>();

            services.AddMvc()
                .AddJsonOptions(x => x.UseCamelCasing(true));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware();
            }
            else
                app.UseStatusCodePagesWithRedirects("/Error?code={0}");

            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
