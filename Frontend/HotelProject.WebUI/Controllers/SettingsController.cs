using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Settings.Profile;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Profile()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditUserProfile()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.Name = user.Name;
            model.Surname = user.Surname;
            model.Email = user.Email;
            model.Username = user.UserName;

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditUserProfile(UserEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Password == model.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (user != null)
                {
                    user.Name = model.Name;
                    user.Surname = model.Surname;
                    user.Email = model.Email;

                    var passwordHasher = _userManager.PasswordHasher.HashPassword(user, model.Password);
                    user.PasswordHash = passwordHasher;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Profile");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User not found.");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Passwords do not match.");
            }

            return View(model);
        }

        public IActionResult Signout()
        {
            return RedirectToAction("Index", "Default");
        }
    }
}
