using AutoMapper;
using GeoEvents.Application.CheckedGeoEvents.Commands.CreateGeoEvent;
using GeoEvents.Application.Common.Mappings;
using GeoEvents.Application.ConsideredGeoEvents.Commands.CreateGeoEvent;

namespace GeoEvents.Mvc.ViewModels
{
    //Когда с клиента приходят данные о создаваемом GeoEvent
    //Т.к. клиент не должен знать свой id, нужен маппинг
    public class CreateConsideredGeoEventDto : IMapWith<CreateCheckedGeoEventCommand>
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateConsideredGeoEventDto, CreateConsideredGeoEventCommand>()
                .ForMember(geoEventCommand => geoEventCommand.Title,
                    opt => opt.MapFrom(geoEventDto => geoEventDto.Title))
                .ForMember(geoEventCommand => geoEventCommand.Details,
                    opt => opt.MapFrom(geoEventDto => geoEventDto.Details))
                .ForMember(geoEventCommand => geoEventCommand.Latitude,
                    opt => opt.MapFrom(geoEventDto => geoEventDto.Latitude))
                .ForMember(geoEventCommand => geoEventCommand.Longitude,
                    opt => opt.MapFrom(geoEventDto => geoEventDto.Longitude));
        }
    }
}
