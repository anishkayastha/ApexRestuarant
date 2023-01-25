using ApexRestaurant.Repository.Domain;
using ApexRestaurant.Services.SMenu;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Cors;

namespace ApexRestaurant.Api.Controller 
{
    [Route("api/menu")]
    //[EnableCors("AllowOrigin")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var menu = _menuService.GetById(id);
            if (menu == null)
                return NotFound();
            return Ok(menu);
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            var menus = _menuService.GetAll();
            return Ok(menus);
        }

        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] Menu model)
        {
            _menuService.Insert(model);
            return Ok();
        }

        [HttpPut]
        [Route("")]
        public IActionResult Put([FromBody] Menu model)
        {
            _menuService.Update(model);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _menuService.Delete(id);
            return Ok();
        }
    }
}