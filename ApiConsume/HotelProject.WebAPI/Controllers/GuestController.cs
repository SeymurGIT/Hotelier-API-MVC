using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _guestService;
        public GuestController(IGuestService guestService)
        {
            _guestService = guestService;
        }
        [HttpGet]
        public IActionResult GuestList()
        {
            var guestsList = _guestService.TGetList();
            return Ok(guestsList);
        }
        [HttpPut]
        public IActionResult UpdateGuest(Guest guest)
        {
            _guestService.TUpdate(guest);
            return Ok();

        }
        [HttpPost]
        public IActionResult AddGuest(Guest guest)
        {
            _guestService.TInsert(guest);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetGuest(int id)
        {
            var guestToGet = _guestService.TGetById(id);
            return Ok(guestToGet);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteGuest(int id)
        {
            var expectedId = _guestService.TGetById(id);
            _guestService.TDelete(expectedId);
            return Ok();
        }
    }
}
