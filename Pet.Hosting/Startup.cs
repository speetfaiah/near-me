using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pet.Hosting.Configs;
using Pet.Hosting.Interfaces;
using Pet.Hosting.Implemetations;
using Pet.Services.Implemetations;
using Pet.Services.Interfaces;

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
            var dataServiceConfig = new DataServiceConfig();
            _configuration.Bind("dataServiceConfig", dataServiceConfig);

            services.AddSingleton<IDataService, DataService>();
            services.AddSingleton<IVkService>(new VkService(dataServiceConfig.VkConfig));

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
