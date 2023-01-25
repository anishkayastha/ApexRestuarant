using ApexRestaurant.Repository.Domain;
using ApexRestaurant.Services.SMealDish;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Cors;

namespace ApexRestaurant.Api.Controller
{
    [Route("api/mealdish")]
    //[EnableCors("AllowOrigin")]
    public class MealDishController : ControllerBase
    {
        private readonly IMealDishService _mealDishService;
        public MealDishController(IMealDishService mealDishService)
        {
            _mealDishService = mealDishService;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var mealDish = _mealDishService.GetById(id);
            if (mealDish == null)
                return NotFound();
            return Ok(mealDish);
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            var mealDish = _mealDishService.GetAll();
            return Ok(mealDish);
        }

        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] MealDish model)
        {
            _mealDishService.Insert(model);
            return Ok();
        }

        [HttpPut]
        [Route("")]
        public IActionResult Put([FromBody] MealDish model)
        {
            _mealDishService.Update(model);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _mealDishService.Delete(id);
            return Ok();
        }
    }
}