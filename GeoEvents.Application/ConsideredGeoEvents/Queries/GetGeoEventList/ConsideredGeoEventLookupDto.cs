using AutoMapper;
using MediatR;
using GeoEvents.Domain;
using GeoEvents.Application.Common.Mappings;


namespace GeoEvents.Application.ConsideredGeoEvents.Queries.GetGeoEventList
{
    //For get list GeoEvents.
    public class ConsideredGeoEventLookupDto : IMapWith<GeoEventConsidered>
    {
        //Каждое событие списка должно иметь лишь те поля
        //которые нужна самому списку событий
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GeoEventConsidered, ConsideredGeoEventLookupDto>()
                .ForMember(geoEventDto => geoEventDto.Id,
                    opt => opt.MapFrom(geoEvent => geoEvent.Id))
                .ForMember(geoEventDto => geoEventDto.Title,
                    opt => opt.MapFrom(geoEvent => geoEvent.Title));
        }

    }
}
