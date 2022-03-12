using Microsoft.AspNetCore.Mvc;

namespace GeoEvents.Mvc.Controllers
{
    public class AccountController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
