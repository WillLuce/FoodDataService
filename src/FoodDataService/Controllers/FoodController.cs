using FoodDataService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FoodDataService.Controllers
{
    [Route("food")]
    public class FoodController : Controller
    {
        private readonly FoodDataRepository _foodData;

        public FoodController(IConfiguration configuration)
        {
            _foodData = new FoodDataRepository(configuration);
        }

        [HttpGet]
        [Route("description/{ndbNo}")]
        public IActionResult Description(string ndbNo)
        {
            var description = _foodData.GetFoodDescriptionByNdbNo(ndbNo);
            return Ok(description);
        }
    }
}
