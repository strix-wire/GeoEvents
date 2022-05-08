using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GeoEvents.Application.ConsideredGeoEvents.Commands.CreateGeoEvent;
using GeoEvents.Mvc.ViewModels;

namespace GeoEvents.Mvc.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;
        public UserController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public IActionResult CreateConsiderEvent()
        {
            return View();
        }

        //Подача заявки на рассмотрение
        [HttpPost]
        public async Task<IActionResult> CreateConsiderEvent(CreateConsideredGeoEventDto createConsideredGeoEventDto)
        {
            //сформируем команду и добавим к ней id user
            var command = _mapper.Map<CreateConsideredGeoEventCommand>(createConsideredGeoEventDto);
            command.UserId = UserId;
            await Mediator.Send(command);

            ViewBag.Message = "Заявка на рассмотрение создания события успешно отправлена!";
            return View("../Home/SuccessfulComeBack");
        }
    }
}
