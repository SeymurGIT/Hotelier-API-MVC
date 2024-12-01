using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }
        [HttpGet]
        public IActionResult TestimonialList()
        {
            var testimonialsList = _testimonialService.TGetList();
            return Ok(testimonialsList);
        }
        [HttpPut]
        public IActionResult UpdateStaff(Testimonial testimonial)
        {
            _testimonialService.TUpdate(testimonial);
            return Ok();

        }
        [HttpPost]
        public IActionResult AddStaff(Testimonial testimonial)
        {
            _testimonialService.TInsert(testimonial);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetStaff(int id)
        {
            var staffToGet = _testimonialService.TGetById(id);
            return Ok(staffToGet);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStaff(int id)
        {
            var expectedId = _testimonialService.TGetById(id);
            _testimonialService.TDelete(expectedId);
            return Ok();
        }
    }
}
