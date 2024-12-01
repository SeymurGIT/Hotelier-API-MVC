using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.RegisterDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Signup(CreateNewUserDto createNewUserDto)
        {
            if(ModelState.IsValid)
            {
                var appUser = new AppUser()
                {
                    Name = createNewUserDto.Name,
                    Email = createNewUserDto.Mail,
                    Surname = createNewUserDto.Surname,
                    UserName = createNewUserDto.Username,
                    WorkLocationID = 1
                };
            var result = await _userManager.CreateAsync(appUser, createNewUserDto.Password);

            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            foreach (IdentityError err in result.Errors)
            {
                ModelState.AddModelError("", err.Description);
            }
        }
                return View("Index", createNewUserDto);
        }
        
    }
}
