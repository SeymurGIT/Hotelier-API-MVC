using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
namespace HotelProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkLocationController : ControllerBase
    {
        private readonly IWorkLocationService _workLocationService;

        public WorkLocationController(IWorkLocationService workLocationService)
        {
            _workLocationService = workLocationService;
        }

        [HttpGet]
        public IActionResult WorkLocationList()
        {
            var locationList = _workLocationService.TGetList();
            return Ok(locationList);
        }
        [HttpPut]
        public IActionResult UpdateWorkLocation(WorkLocation location)
        {
            _workLocationService.TUpdate(location);
            return Ok();

        }
        [HttpPost]
        public IActionResult AddWorkLocation(WorkLocation location)
        {
            _workLocationService.TInsert(location);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetWorkLocation(int id)
        {
            var workLocationToGet = _workLocationService.TGetById(id);
            return Ok(workLocationToGet);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteWorkLocation(int id)
        {
            var expectedId = _workLocationService.TGetById(id);
            _workLocationService.TDelete(expectedId);
            return Ok();
        }
    }
}
