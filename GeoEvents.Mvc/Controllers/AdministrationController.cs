using GeoEvents.Mvc.ViewModels;
using GeoEvents.Persistence.IdentityEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GeoEvents.Mvc.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdministrationController : BaseController
    {
        private readonly UserManager<MyIdentityUser> _userManager;
        readonly RoleManager<IdentityRole> _roleManager;
        public AdministrationController(RoleManager<IdentityRole> roleManager,
                                        UserManager<MyIdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpPost]
        public IActionResult Index()
        {
            return View();
        }

        #region CreateRole
        //public async Task<IActionResult> CreateRole()
        //{
        //    IdentityRole identityRole = new IdentityRole
        //    {
        //        Name = "Admin"
        //    };

        //    IdentityResult result = await _roleManager.CreateAsync(identityRole);

        //    IdentityRole identityRole2 = new IdentityRole
        //    {
        //        Name = "User"
        //    };

        //    IdentityResult result2 = await _roleManager.CreateAsync(identityRole2);

        //    IdentityRole identityRole3 = new IdentityRole
        //    {
        //        Name = "Moderator"
        //    };

        //    IdentityResult result3 = await _roleManager.CreateAsync(identityRole3);

        //    return RedirectToAction("index", "home");
        //}
        #endregion

        #region MakeUserToAdmin
        //public async Task<IActionResult> MakeUserToAdmin()
        //{
        //    var user = await _userManager.FindByIdAsync("49b723da-1cd9-483a-9447-a6c2115fddba");

        //    var result = await _userManager.AddToRoleAsync(user, "Admin");

        //    return RedirectToAction("index", "home");
        //}
        #endregion

        [HttpGet]
        public IActionResult UserList() => View(_userManager.Users.ToList());

        [HttpGet]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);

                return View("DeleteUserSuccessful", "Administration");
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> EditRoleUser(string userId)
        {
            // получаем пользователя
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                ChangeRoleViewModel model = new ChangeRoleViewModel
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EditRoleUser(string userId, List<string> roles)
        {
            // получаем пользователя
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);
                // получаем все роли
                var allRoles = _roleManager.Roles.ToList();
                // получаем список ролей, которые были добавлены
                var addedRoles = roles.Except(userRoles);
                // получаем роли, которые были удалены
                var removedRoles = userRoles.Except(roles);

                await _userManager.AddToRolesAsync(user, addedRoles);

                await _userManager.RemoveFromRolesAsync(user, removedRoles);

                return RedirectToAction("UserList");
            }

            return NotFound();
        }
    }
}
