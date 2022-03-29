using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeoEvents.Mvc.Controllers
{
    [Authorize(Roles = "Admin")]
    [Authorize(Roles = "Moderator")]
    public class ModeratorController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        //public IActionResult ConsiderationOfRequestForNewEvents()
        //{

        //}
    }
}
