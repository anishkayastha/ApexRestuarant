using ApexRestaurant.Repository.Domain;
using ApexRestaurant.Services.SStaffRole;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Cors;

namespace ApexRestaurant.Api.Controller
{
    [Route("api/staffrole")]
    //[EnableCors("AllowOrigin")]
    public class StaffRoleController : ControllerBase
    {
        private readonly IStaffRoleService _staffRoleService;
        public StaffRoleController(IStaffRoleService staffRoleService)
        {
            _staffRoleService = staffRoleService;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var staffRole = _staffRoleService.GetById(id);
            if (staffRole == null)
                return NotFound();
            return Ok(staffRole);
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            var staffRoles = _staffRoleService.GetAll();
            return Ok(staffRoles);
        }

        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] StaffRole model)
        {
            _staffRoleService.Insert(model);
            return Ok();
        }

        [HttpPut]
        [Route("")]
        public IActionResult Put([FromBody] StaffRole model)
        {
            _staffRoleService.Update(model);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _staffRoleService.Delete(id);
            return Ok();
        }
    }
}