using System;
using AutoMapper;
using KanbanBoard.Core.Infrastucture;
using KanbanBoard.Core.Services;
using KanbanBoard.Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KanbanBoard.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services
                .AddAuthentication(options =>
                {
                    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
                .AddCookie(options =>
                {
                    options.LoginPath = "/Auth/Login";
                    options.LogoutPath = "/Auth/Logout";
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                });

            services.AddAutoMapper(typeof(Startup));

            InitializeDependencyInjectionService(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=KanbanBoard}/{action=Index}/{id?}");
            });
        }

        private static void InitializeDependencyInjectionService(IServiceCollection services)
        {
            services.AddSingleton<IClockService, UtcClockService>();

            services.AddScoped<KanbanBoardService, KanbanBoardService>();
            services.AddScoped<IPostItRepository, InMemoryPostItRepository>();
            services.AddScoped<IUserRepository, InMemoryUserRepository>();
        }
    }
}