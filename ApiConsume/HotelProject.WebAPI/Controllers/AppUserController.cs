using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HotelProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        private readonly Context _context;

        public AppUserController(IAppUserService appUserService, Context context)
        {
            _appUserService = appUserService;
            _context = context;
        }
        [HttpGet]
        public IActionResult UserListWithWorkLocation()
        {
            //var userWithWorkLocationList = _appUserService.TUsersWithWorkLocations();

            var values = _context.Users.Include(s => s.WorkLocation).Select(z => new AppUserWorkLocationViewModel
            {
                Name = z.Name,
                Surname = z.Surname,
                WorkLocationID = z.WorkLocationID,
                WorkLocationName = z.WorkLocation.WorkLocationName
            });
            return Ok(values);
        }
        [HttpGet("Users")]
        public IActionResult Users()
        {
            var userList = _appUserService.TUsers();
            return Ok(userList);
        }
    }
}
