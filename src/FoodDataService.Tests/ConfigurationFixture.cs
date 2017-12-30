using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace FoodDataService.Tests
{
    class ConfigurationFixture : IDisposable
    {
        public ConfigurationFixture()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();

            Startup.Configuration = builder.Build();
        }
        public void Dispose()
        {

        }
    }
}