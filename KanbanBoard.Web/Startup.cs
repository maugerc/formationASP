using KanbanBoard.Core.Infrastucture;
using KanbanBoard.Core.Services;
using KanbanBoard.Infrastructure;
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

            InitializeDependencyInjectionService(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=KanbanBoard}/{action=Index}/{id?}");
            });
        }

        private static void InitializeDependencyInjectionService(IServiceCollection services)
        {
            services.AddScoped<KanbanBoardService, KanbanBoardService>();

            services.AddScoped<IPostItRepository, InMemoryPostItRepository>();
        }
    }
}
