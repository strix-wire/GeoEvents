using AutoMapper;
using MediatR;
using GeoEvents.Domain;
using GeoEvents.Application.Common.Mappings;


namespace GeoEvents.Application.CheckedGeoEvents.Queries.GetGeoEventList
{
    //For get list GeoEvents.
    public class CheckedGeoEventLookupDto : IMapWith<GeoEvent>
    {
        //Каждое событие списка должно иметь лишь те поля
        //которые нужна самому списку событий
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GeoEvent, CheckedGeoEventLookupDto>()
                .ForMember(geoEventDto => geoEventDto.Id,
                    opt => opt.MapFrom(geoEvent => geoEvent.Id))
                .ForMember(geoEventDto => geoEventDto.Title,
                    opt => opt.MapFrom(geoEvent => geoEvent.Title));
        }

    }
}
