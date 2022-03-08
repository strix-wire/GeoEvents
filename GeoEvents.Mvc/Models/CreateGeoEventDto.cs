﻿using GeoEvents.Application.Common.Mappings;
using GeoEvents.Application.GeoEvents.Commands.CreateGeoEvent;

namespace GeoEvents.Mvc.Models
{
    //Когда с клиента приходят данные о создаваемом GeoEvent
    //Т.к. клиент не должен знать свой id, нужен маппинг
    public class CreateGeoEventDto : IMapWith<CreateGeoEventCommand>
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateGeoEvent, CreateGeoEventCommand>()
                .ForMember(geoEventCommand => geoEventCommand.Title,
                    opt => opt.MapFrom(geoEventDto => geoEventDto.Title))
                .ForMember(geoEventCommand => geoEventCommand.Details,
                    opt => opt.MapFrom(geoEventDto => geoEventDto.Details));
        }
    }
}
