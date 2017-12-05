using System.Linq;
using Microsoft.AspNetCore.Hosting;

namespace FoodDataService.Utils
{
    public static class EnvironmentUtils
    {
        public static readonly string[] Environments = { "dev", "prod" };

        public static string GetEnvironment(this IHostingEnvironment env)
        {
            return Environments.Contains(env?.EnvironmentName.ToLower()) ? env?.EnvironmentName : "local";
        }
    }
}