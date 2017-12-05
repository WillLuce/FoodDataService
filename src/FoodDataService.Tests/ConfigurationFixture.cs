using System;
using System.IO;
using FoodDataService;
using Microsoft.Extensions.Configuration;

namespace CatalogService.Tests
{
    public class ConfigurationFixture : IDisposable
    {
        public ConfigurationFixture()
        {

            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")?.ToLower() ?? "local";

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json")
                .AddJsonFile($"appsettings.{env}.json", true)
                .AddEnvironmentVariables();
            Startup.Configuration = builder.Build();
        }
        public void Dispose()
        {

        }
    }
}