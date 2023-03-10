using ApexRestaurant.Repository.Domain;
using ApexRestaurant.Services.SStaff;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Cors;

namespace ApexRestaurant.Api.Controller
{
    [Route("api/staff")]
    //[EnableCors("AllowOrigin")]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;
        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var staff = _staffService.GetById(id);
            if (staff == null)
                return NotFound();
            return Ok(staff);
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            var staffs = _staffService.GetAll();
            return Ok(staffs);
        }

        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] Staff model)
        {
            _staffService.Insert(model);
            return Ok();
        }

        [HttpPut]
        [Route("")]
        public IActionResult Put([FromBody] Staff model)
        {
            _staffService.Update(model);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _staffService.Delete(id);
            return Ok();
        }
    }
}