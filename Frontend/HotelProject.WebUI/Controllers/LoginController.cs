using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.LoginDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginDto userLoginDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(userLoginDto.Email);

                if (user != null)
                {
                    await _signInManager.SignOutAsync();


                    var res = await _signInManager.PasswordSignInAsync(user, userLoginDto.Password, false, false);

                    if (res.Succeeded)
                    {
                        await _userManager.ResetAccessFailedCountAsync(user);
                        return RedirectToAction("Index", "Staff");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Yanlış email ünvanı və ya şifrə");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Belə bir hesab mövcud deyil");
                }
            }
            return View(userLoginDto);
        }

    }
}


/*Alternative way
           var user = await _userManager.FindByEmailAsync(userLoginDto.Email);

           if(user!=null)
           {
               await _signInManager.SignOutAsync();
               var result = await _signInManager.PasswordSignInAsync(userLoginDto.Email, userLoginDto.Password, false, false);

           if(result.Succeeded)
           {
               return RedirectToAction("Index", "Staff");
           }
           else
               {
                   ModelState.AddModelError("", "Yanlış email ünvanı və ya şifrə");
               }
           }
           else
           {
               ModelState.AddModelError("", "Belə bir hesab mövcud deyil");
           }
       }
       return View(); */


