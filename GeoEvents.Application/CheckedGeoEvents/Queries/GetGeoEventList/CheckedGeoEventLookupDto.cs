using AutoMapper;
using MediatR;
using GeoEvents.Domain;
using GeoEvents.Application.Common.Mappings;


namespace GeoEvents.Application.CheckedGeoEvents.Queries.GetGeoEventList
{
    //For get list GeoEvents.
    public class CheckedGeoEventLookupDto : IMapWith<GeoEventChecked>
    {
        //Каждое событие списка должно иметь лишь те поля
        //которые нужна самому списку событий
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Details { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GeoEventChecked, CheckedGeoEventLookupDto>()
                .ForMember(geoEventDto => geoEventDto.Id,
                    opt => opt.MapFrom(geoEvent => geoEvent.Id))
                .ForMember(geoEventDto => geoEventDto.Title,
                    opt => opt.MapFrom(geoEvent => geoEvent.Title))
                .ForMember(geoEventDto => geoEventDto.Details,
                    opt => opt.MapFrom(geoEvent => geoEvent.Details))
                .ForMember(geoEventDto => geoEventDto.Latitude,
                    opt => opt.MapFrom(geoEvent => geoEvent.Latitude))
                .ForMember(geoEventDto => geoEventDto.Longitude,
                    opt => opt.MapFrom(geoEvent => geoEvent.Longitude))
                .ForMember(geoEventDto => geoEventDto.CreationDate,
                    opt => opt.MapFrom(geoEvent => geoEvent.CreationDate))
                .ForMember(geoEventDto => geoEventDto.EditDate,
                    opt => opt.MapFrom(geoEvent => geoEvent.EditDate));
        }

    }
}
