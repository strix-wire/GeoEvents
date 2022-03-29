using AutoMapper;
using GeoEvents.Mvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GeoEvents.Application.GeoEvents.Commands.CreateGeoEvent;

namespace GeoEvents.Mvc.Controllers
{
    [Authorize(Roles = "User")]
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;
        public UserController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<IActionResult> Create(CreateGeoEventDto createGeoEventDto)
        {
            //сформируем команду и добавим к ней id user
            var command = _mapper.Map<CreateConsideredGeoEventCommand>(createGeoEventDto);
            command.UserId = UserId;
            var geoEventId = await Mediator.Send(command);
            return Redirect("Index");
        }

    }
}
