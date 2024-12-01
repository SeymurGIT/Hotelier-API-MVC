using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HotelProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public IActionResult StaffList()
        {
            var staffsList = _staffService.TGetList();
            return Ok(staffsList);
        }
        [HttpPut]
        public IActionResult UpdateStaff(Staff staff)
        {
            _staffService.TUpdate(staff);
            return Ok();

        }
        [HttpPost]
        public IActionResult AddStaff(Staff staff)
        {
            _staffService.TInsert(staff);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetStaff(int id)
        {
            var staffToGet = _staffService.TGetById(id);
            return Ok(staffToGet);
        }
        [HttpGet("Last4Staffs")]
        public IActionResult Last4Staffs()
        {
            var values = _staffService.TLast4Staffs();
            return Ok(values);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStaff(int id)
        {
            var expectedId = _staffService.TGetById(id);
            _staffService.TDelete(expectedId);
            return Ok();
        }
    }
}
