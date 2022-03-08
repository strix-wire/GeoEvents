using AutoMapper;
using GeoEvents.Application.Common.Mappings;
using GeoEvents.Application.GeoEvents.Commands.UpdateGeoEvent;

namespace GeoEvents.Mvc.Models
{
    public class UpdateGeoEventDto : IMapWith<UpdateGeoEventCommand>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateGeoEventDto, UpdateGeoEventCommand>()
                .ForMember(geoEventCommand => geoEventCommand.Id,
                    opt => opt.MapFrom(geoEventDto => geoEventDto.Id))
                .ForMember(geoEventCommand => geoEventCommand.Title,
                    opt => opt.MapFrom(geoEventDto => geoEventDto.Title))
                .ForMember(geoEventCommand => geoEventCommand.Details,
                    opt => opt.MapFrom(geoEventDto => geoEventDto.Details));
        }


    }
}
