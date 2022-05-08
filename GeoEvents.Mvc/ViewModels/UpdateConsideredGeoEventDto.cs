using AutoMapper;
using GeoEvents.Application.CheckedGeoEvents.Commands.UpdateGeoEvent;
using GeoEvents.Application.Common.Mappings;

namespace GeoEvents.Mvc.ViewModels
{
    public class UpdateCheckedGeoEventDto : IMapWith<UpdateCheckedGeoEventCommand>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Latitude { get; set; }
        public double Longitude { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCheckedGeoEventDto, UpdateCheckedGeoEventCommand>()
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
