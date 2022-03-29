using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeoEvents.Mvc.Controllers
{
    [Authorize(Roles = "Moderator")]
    public class ModeratorController : BaseController
    {
        
        public IActionResult Index()
        {
            return View();
        }
        
        //public IActionResult ConsiderationOfRequestForNewEvents()
        //{

        //}
    }
}
