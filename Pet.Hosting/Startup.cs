using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pet.Hosting.Models;
using Pet.VkApi.Interfaces;
using Pet.VkApi.Services;
using System;

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
                .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var vkConfig = _configuration.GetSection("vk").Get<VkConfig>();
 
            services.AddSingleton<IMessageService, MessageService>();

            services.AddHttpClient<BaseService>(h =>
            {
                h.BaseAddress = new Uri(vkConfig.ApiUrl);
                h.Timeout = TimeSpan.FromSeconds(vkConfig.Timeout);
            });

            services.AddSingleton<IAuthService, AuthService>();
            services.AddHttpClient<AuthService>(h =>
            {
                h.BaseAddress = new Uri(vkConfig.OauthUrl);
                h.Timeout = TimeSpan.FromSeconds(vkConfig.Timeout);
            });

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
