using GeoEvents.Mvc.ViewModels;
using GeoEvents.Persistence.IdentityEF;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GeoEvents.Mvc.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserManager<MyIdentityUser> _userManager;
        private readonly SignInManager<MyIdentityUser> _signInManager;
        public AccountController(UserManager<MyIdentityUser> userManager,
                                    SignInManager<MyIdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new MyIdentityUser
                {
                    UserName = model.Email,
                    Name = model.Name,
                    Email = model.Email,
                    Surname = model.Surname,
                    MiddleName = model.MiddleName,
                    //DateOfBirth = model.DateOfBirth,
                    City = model.City,
                    //Sex = model.Sex
                };
                //пароль хешируется сам и надежно хранится в бд
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    //false - сессионный файл куки
                    await _userManager.AddToRoleAsync(user, "User");
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }

                //если есть ошибка - перебираем все
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                //асинхронный метод входа с паролем
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                //если успешно вошли
                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

                //если не успешно
                ModelState.AddModelError(string.Empty, "Неверный email или пароль");
            }

            return View(model);
        }

        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                //Json для jquery
                return Json(true);
            }
            else
            {
                return Json($"Email {email} уже используется");
            }
        }

        ////Список предложенных событий
        //[HttpGet]
        //public async Task<ActionResult<ConsideredGeoEventListVm>> GetListConsiderationOfRequestForNewEvents()
        //{
        //    var query = new ConsideredGetGeoEventListQuery()
        //    {
        //        UserId = UserId
        //    };
        //    var vm = await Mediator.Send(query);

        //    return View(vm);
        //}

        ////Список созданных событий
        //[HttpGet]
        //public async Task<ActionResult<CheckedGeoEventListVm>> GetListCheckedEvents()
        //{
        //    var query = new CheckedGetGeoEventListQuery()
        //    {
        //        UserId = UserId
        //    };
        //    var vm = await Mediator.Send(query);

        //    return View(vm);
        //}
    }
}
