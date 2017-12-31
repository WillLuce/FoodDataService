using FoodDataService.Data;
using FoodDataService.Utils;
using Microsoft.AspNetCore.Mvc;

namespace FoodDataService.Controllers.v1
{
    [Route("v1/food")]
    public class FoodController : Controller
    {
        private readonly FoodDataRepository _foodData;

        public FoodController(FoodDataRepository foodDataRepository)
        {
            _foodData = foodDataRepository;
        }

        [HttpGet]
        [Route("{ndbNo}")]
        public IActionResult GetFoodDescriptionByNdbNo(string ndbNo)
        {
            var description = _foodData.GetFoodDescriptionByNdbNo(ndbNo);

            if (description == null)
            {
                return NotFound();
            }

            return Ok(description.ToFoodDescriptionResponse());
        }
    }
}
