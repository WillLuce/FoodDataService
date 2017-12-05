using CatalogService.Tests;
using FoodDataService.Data;
using Xunit;

namespace FoodDataService.Tests.Data
{
    public class FoodDataTests : IClassFixture<ConfigurationFixture>, IClassFixture<FoodDataFixture>
    {
        private readonly FoodData _data;
        private readonly FoodDataFixture _foodDataFixture;

        public FoodDataTests(FoodDataFixture foodDataFixture)
        {
            _foodDataFixture = foodDataFixture;
            _data = new FoodData();
        }

        [Fact]
        public void GetFoodDescriptionByNdbNo()
        {
            var ndb_no = "00000";

            var result = _data.GetFoodDescriptionByNdbNo(ndb_no);

            Assert.NotNull(result);
            Assert.Equal(ndb_no, result.Ndb_No);
        }
    }
}
