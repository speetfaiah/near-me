using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pet.Hosting.Interfaces;
using Pet.Hosting.Implemetations;
using Pet.Services.Implemetations;
using Pet.Services.Interfaces;
using Pet.Hosting.Models;
using Pet.Services.Models.Vk;
using Pet.Services.Models.Flickr;

namespace Pet.Hosting
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
