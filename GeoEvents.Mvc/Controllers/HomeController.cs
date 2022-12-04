﻿using AutoMapper;
using GeoEvents.Application.CheckedGeoEvents.Queries.GetGeoEventDetails;
using GeoEvents.Application.CheckedGeoEvents.Queries.GetGeoEventList;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace GeoEvents.Mvc.Controllers 
{
    public class HomeController : BaseController
    {
        private readonly IMapper _mapper;
        public HomeController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var queryListGeoEvent = new CheckedGetGeoEventListQuery()
            {
                UserId = UserId
            };

            HttpRequestMessage httpRequestMessage = new();
            httpRequestMessage.Method = HttpMethod.Get;
            httpRequestMessage.RequestUri = new Uri("http://192.168.1.102:8565/api/v1/geodata/GetGeodataList");

            var payload = new { UserId = Guid.NewGuid() };
            var stringPayload = JsonConvert.SerializeObject(payload);
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            httpRequestMessage.Content = httpContent;

            HttpClient httpClient = new();
            var httpResponse = await httpClient.SendAsync(httpRequestMessage);
            var resString = await httpResponse.Content.ReadAsStringAsync();

            var res = JsonConvert.DeserializeObject<CheckedGeoEventListVm>(resString);

            return View(res);
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
