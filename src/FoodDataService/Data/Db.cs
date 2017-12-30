using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace FoodDataService.Data
{
    public class Db
    {
        public static IDbConnection FoodDataService()
        {
            return new NpgsqlConnection(Startup.Configuration.GetConnectionString("UsdaSr28"));
        }
    }
}
