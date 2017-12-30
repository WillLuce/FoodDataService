using FoodDataService.Data;
using Microsoft.AspNetCore.Mvc;

namespace FoodDataService.Controllers
{
    [Route("food")]
    public class FoodController : Controller
    {
        private readonly FoodDataRepository _foodData;

        public FoodController()
        {
            _foodData = new FoodDataRepository();
        }

        [HttpGet]
        [Route("description/{ndbNo}")]
        public IActionResult Description(string ndbNo)
        {
            var description = _foodData.GetFoodDescriptionByNdbNo(ndbNo);

            if (description == null)
            {
                return NotFound();
            }

            return Ok(description);
        }
    }
}
