using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        //Listing Roles
        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }

        //Adding Roles

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }
        public async Task<IActionResult> AddRole(AddRoleViewModel model)
        {
            var appRole = new AppRole()
            {
                Name = model.RoleName
            };
            var result = await _roleManager.CreateAsync(appRole);

            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Role");
            }
            return View();

        }

        //Deleting Roles
        public async Task<IActionResult> DeleteRole(int id)
        {
            var targetRole = _roleManager.Roles.FirstOrDefault(s => s.Id == id);
            await _roleManager.DeleteAsync(targetRole);
            return RedirectToAction("Index");
        }

        //Updating the Roles

        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var targetRole = _roleManager.Roles.FirstOrDefault(s => s.Id == id);

            UpdateRoleViewModel model = new UpdateRoleViewModel()
            {
                RoleID = targetRole.Id,
                RoleName = targetRole.Name
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleViewModel model)
        {
            var targetRole = _roleManager.Roles.FirstOrDefault(s => s.Id == model.RoleID);
            targetRole.Name = model.RoleName;
            await _roleManager.UpdateAsync(targetRole);
            return RedirectToAction("Index");
        }
    }
}
