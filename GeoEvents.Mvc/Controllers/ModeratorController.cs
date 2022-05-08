using AutoMapper;
using GeoEvents.Application.CheckedGeoEvents.Commands.CreateGeoEvent;
using GeoEvents.Application.CheckedGeoEvents.Commands.DeleteGeoEvent;
using GeoEvents.Application.CheckedGeoEvents.Commands.UpdateGeoEvent;
using GeoEvents.Application.CheckedGeoEvents.Queries.GetGeoEventDetails;
using GeoEvents.Application.CheckedGeoEvents.Queries.GetGeoEventList;
using GeoEvents.Application.ConsideredGeoEvents.Commands.DeleteGeoEvent;
using GeoEvents.Application.ConsideredGeoEvents.Commands.UpdateGeoEvent;
using GeoEvents.Application.ConsideredGeoEvents.Queries.GetGeoEventDetails;
using GeoEvents.Application.ConsideredGeoEvents.Queries.GetGeoEventList;
using GeoEvents.Mvc.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeoEvents.Mvc.Controllers
{
    [Authorize(Roles = "Moderator")]
    public class ModeratorController : BaseController
    {
        private readonly IMapper _mapper;

        public ModeratorController(IMapper mapper)
        {
            _mapper = mapper;
        }

        //Возможности роли модератора
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //Редактирование предложенного события
        [HttpGet]
        public async Task<IActionResult> EditConsideredEvent(Guid id)
        {
            var query = new ConsideredGetGeoEventDetailsQuery()
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);

            var EditConsideredEventVm = _mapper.Map<EditConsideredGeoEventDetails>(vm);
            return View(EditConsideredEventVm);
        }

        //Редактирование созданного события
        [HttpGet]
        public async Task<IActionResult> EditCheckedEvent(Guid id)
        {
            var query = new CheckedGetGeoEventDetailsQuery()
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);

            var EditCheckedEventVm = _mapper.Map<EditCheckedGeoEventDetails>(vm);
            return View(EditCheckedEventVm);
        }

        //Редактирование предложенного события
        [HttpPost]
        public async Task<IActionResult> EditConsideredEvent(UpdateConsideredGeoEventDto updateConsideredGeoEventDto)
        {
            var command = _mapper.Map<UpdateConsideredGeoEventCommand>(updateConsideredGeoEventDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            ViewBag.Message = "Событие успешно отредактировано!";

            return View("../Home/SuccessfulComeBack");
        }
        
        //Редактирование созданного события
        [HttpPost]
        public async Task<IActionResult> EditCheckedEvent(UpdateCheckedGeoEventDto updateEditGeoEventDto)
        {
            var command = _mapper.Map<UpdateCheckedGeoEventCommand>(updateEditGeoEventDto);
            command.UserId = UserId;
            await Mediator.Send(command);

            ViewBag.Message = "Событие успешно отредактировано!";

            return View("../Home/SuccessfulComeBack");
        }

        //Сразу создать новое событие
        [HttpGet]
        public IActionResult CreateCheckedEvent()
        {
            return View();
        }

        //Сразу создать новое событие
        [HttpPost]
        public async Task<IActionResult> CreateCheckedEvent(CreateCheckedGeoEventDto createCheckedGeoEventDto)
        {
            //сформируем команду и добавим к ней id user
            var command = _mapper.Map<CreateCheckedGeoEventCommand>(createCheckedGeoEventDto);
            command.UserId = UserId;
            await Mediator.Send(command);

            ViewBag.Message = "Событие успешно создано!";

            return View("../Home/SuccessfulComeBack");
        }

        //Создает событие из предложенного
        //Удаляет предложенное
        [HttpPost]
        public async Task<IActionResult> CreateCheckedEventFromConsidered(Guid id)
        {
            //Получение деталей события
            var query = new ConsideredGetGeoEventDetailsQuery()
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);

            //Класс для промежуточного маппинга
            var tempClassMapper = _mapper.Map<CreateCheckedEventFromConsidered>(vm);

            //Создание проверенного события
            var command = _mapper.Map<CreateCheckedGeoEventCommand>(tempClassMapper);
            command.UserId = UserId;
            await Mediator.Send(command);

            //Удаление события из списка рассматриваемых событий
            var command2 = new DeleteConsideredGeoEventCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command2);
            
            ViewBag.Message = "Создано новое проверенное событие! Предложенное событие удалено.";

            return View("../Home/SuccessfulComeBack");
        }

        //Список предложенных событий
        [HttpGet]
        public async Task<ActionResult<ConsideredGeoEventListVm>> GetListConsiderationOfRequestForNewEvents()
        {
            var query = new ConsideredGetGeoEventListQuery()
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);

            return View(vm);
        }

        //Список созданных событий
        [HttpGet]
        public async Task<ActionResult<CheckedGeoEventListVm>> GetListCheckedEvents()
        {
            var query = new CheckedGetGeoEventListQuery()
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);

            return View(vm);
        }

        //Удалить предложенное событие
        [HttpPost]
        public async Task<IActionResult> DeleteConsideredEvent(Guid id)
        {
            var command = new DeleteConsideredGeoEventCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);

            ViewBag.Message = "Предложенное событие успешно удалено!";

            return View("../Home/SuccessfulComeBack");
        }

        //Удалить проверенное событие
        [HttpPost]
        public async Task<IActionResult> DeleteCheckedEvent(Guid id)
        {
            var command = new DeleteCheckedGeoEventCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);

            ViewBag.Message = "Событие успешно удалено!";

            return View("../Home/SuccessfulComeBack");
        }
    }
}
