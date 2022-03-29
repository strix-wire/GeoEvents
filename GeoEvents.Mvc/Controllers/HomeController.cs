using AutoMapper;
using GeoEvents.Mvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GeoEvents.Mvc.Controllers 
{
    public class HomeController : BaseController
    {
        private readonly IMapper _mapper;
        public HomeController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        ////Get list GeoEvents
        //[HttpGet]
        //public async Task<ActionResult<GeoEventListVm>> GetAll()
        //{
        //    var query = new GetGeoEventListQuery()
        //    {
        //        UserId = UserId
        //    };
        //    var vm = await Mediator.Send(query);
        //    return Ok(vm);
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<GeoEventDetailsVm>> Get(Guid id)
        //{
        //    var query = new GetGeoEventDetailsQuery()
        //    {
        //        UserId = UserId,
        //        Id = id
        //    };
        //    var vm = await Mediator.Send(query);
        //    return Ok(vm);
        //}

        ////FromBody - указывает, что параметр метода контроллера должен
        ////быть извлечен из данных тела http запроса и затем десериализован
        ////с помощью формата входных данных
        //[HttpGet]
        //public async Task<IActionResult> Create(CreateGeoEventDto createGeoEventDto)
        //{
        //    //сформируем команду и добавим к ней id user
        //    var command = _mapper.Map<CreateGeoEventCommand>(createGeoEventDto);
        //    command.UserId = UserId;
        //    var geoEventId = await Mediator.Send(command);
        //    return Redirect("Index");
        //}

        //[HttpPut]
        //public async Task<IActionResult> Update([FromBody] UpdateGeoEventDto updateGeoEventDto)
        //{
        //    var command = _mapper.Map<UpdateGeoEventCommand>(updateGeoEventDto);
        //    command.UserId = UserId;
        //    await Mediator.Send(command);
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    var command = new DeleteGeoEventCommand
        //    {
        //        Id = id,
        //        UserId = UserId
        //    };
        //    await Mediator.Send(command);
        //    return NoContent();
        //}
    }
}
