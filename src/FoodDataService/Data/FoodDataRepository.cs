using System.Linq;
using Dapper;
using FoodDataService.Models;

namespace FoodDataService.Data
{
    public class FoodDataRepository
    {
        public virtual FoodDescriptionData GetFoodDescriptionByNdbNo(string ndbNo)
        {
            using (var dbConnection = Db.FoodDataService())
            {
                dbConnection.Open();
                var description = dbConnection.Query<FoodDescriptionData>("SELECT * FROM food_des WHERE ndb_no = @NdbNo", new { NdbNo = ndbNo })
                    .FirstOrDefault();
                return description;
            }
        }
    }
}
