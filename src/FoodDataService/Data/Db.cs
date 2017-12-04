using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace FoodDataService.Data
{
    public static class Db
    {
        public static IDbConnection FoodDataService()
        {
            return new SqlConnection(Startup.Configuration.GetConnectionString("FoodDataService"));
        }
    }
}
