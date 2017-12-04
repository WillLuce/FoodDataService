using System.Data;
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
            using (IDbConnection connection = Db.FoodDataService())
            {
                return connection.Query<FoodDescription>(GetSql("SelectFoodDescriptionByNdbNo.sql"), new { ndb_no }).SingleOrDefault();
            }
        }

        private string GetSql(string name)
        {
            name.CheckNullOrEmpty(nameof(name));
            return StreamUtils.GetResourceStream(GetType(), $"sql.{name}").AsString();
        }
    }
}