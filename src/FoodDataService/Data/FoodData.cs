using FoodDataService.Models;
using Dapper;
using FoodDataService.Utils;
using System.Linq;

namespace FoodDataService.Data
{
    public class FoodData
    {
        public virtual FoodDescription GetFoodDescriptionByNdbNo(string ndb_no)
        {
            using (var connection = Db.FoodDataService())
            {
                connection.Open();
                return connection.Query<FoodDescription>("SELECT * FROM food_des WHERE ndb_no = '00000'").SingleOrDefault();
            }
        }

        private string GetSql(string name)
        {
            name.CheckNullOrEmpty(nameof(name));
            return StreamUtils.GetResourceStream(GetType(), $"sql.{name}").AsString();
        }
    }
}