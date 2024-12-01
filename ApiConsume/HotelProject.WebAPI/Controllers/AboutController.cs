using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService; 

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var aboutsList = _aboutService.TGetList();
            return Ok(aboutsList);
        }
        [HttpPut]
        public IActionResult UpdateAbout(About about)
        {
            _aboutService.TUpdate(about);
            return Ok();

        }
        [HttpPost]
        public IActionResult AddAbout(About about)
        {
            _aboutService.TInsert(about);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var aboutToGet = _aboutService.TGetById(id);
            return Ok(aboutToGet);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var expectedId = _aboutService.TGetById(id);
            _aboutService.TDelete(expectedId);
            return Ok();
        }
    }
}
