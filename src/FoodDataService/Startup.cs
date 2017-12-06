using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FoodDataService.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoodDataService
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddRouting();

            return ConfigureAutoFac(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }

        private IServiceProvider ConfigureAutoFac(IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            services.AddSingleton<FoodData>();

            builder.Populate(services);

            return new AutofacServiceProvider(builder.Build());
        }

        public void Cleanup()
        {
        }
    }
}
