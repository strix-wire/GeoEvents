using AutoMapper;
using GeoEvents.Application.Common.Mappings;
using GeoEvents.Application.ConsideredGeoEvents.Commands.UpdateGeoEvent;

namespace GeoEvents.Mvc.ViewModels
{
    public class UpdateConsideredGeoEventDto : IMapWith<UpdateConsideredGeoEventCommand>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateConsideredGeoEventDto, UpdateConsideredGeoEventCommand>()
                .ForMember(geoEventCommand => geoEventCommand.Id,
                    opt => opt.MapFrom(geoEventDto => geoEventDto.Id))
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
