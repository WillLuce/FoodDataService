using System.Data;
using System.Linq;
using Dapper;
using FoodDataService.Models;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace FoodDataService.Services
{
    public class FoodDataRepository
    {
        private readonly string _connectionString;
        internal IDbConnection Connection => new NpgsqlConnection(_connectionString);

        public FoodDataRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("UsdaSr28");
        }

        public FoodDescription GetFoodDescriptionByNdbNo(string ndbNo)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var description = dbConnection.Query<FoodDescription>("SELECT * FROM food_des WHERE ndb_no = @NdbNo", new { NdbNo = ndbNo })
                    .FirstOrDefault();
                return description;
            }
        }
    }
}
