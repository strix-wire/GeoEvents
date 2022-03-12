using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GeoEvents.Mvc.Controllers
{
    [ApiController]
    public abstract class BaseController : Controller
    {
        private IMediator _mediator;
        //Будет использоваться для формирования команд, выполнения запросов
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        internal Guid UserId => !User.Identity.IsAuthenticated
            ? Guid.Empty
            : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}
