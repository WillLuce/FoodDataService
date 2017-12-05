using System.IO;
using FoodDataService.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace FoodDataService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
                CreateBuilder(args)
                    .UseStartup<Startup>()
                    .Build();

        public static IWebHostBuilder CreateBuilder(string[] args)
        {
            return new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;
                    config.AddJsonFile("appsettings.json", true, true)
                        .AddJsonFile($"appsettings.{env.GetEnvironment()}.json", optional: true, reloadOnChange: true)
                        .AddEnvironmentVariables()
                        .AddCommandLine(args ?? new string[0]);
                });
        }
    }
}
