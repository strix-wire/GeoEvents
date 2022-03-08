using GeoEvents.Application.Common.Mappings;
using GeoEvents.Domain;
using AutoMapper;

namespace GeoEvents.Application.GeoEvents.Queries.GetGeoEventDetails
{
    //Our view model. Class describing details which return user
    //Dont have UserId
    public class GeoEventDetailsVm : IMapWith<GeoEvent>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }

        //Mapping between GeoEvent and GeoEventDetailsVm
        public void Mapping(Profile profile)
        {
            profile.CreateMap<GeoEvent, GeoEventDetailsVm>()
                .ForMember(geoEventVm => geoEventVm.Title,
                    opt => opt.MapFrom(geoEvent => geoEvent.Title))
                .ForMember(geoEventVm => geoEventVm.Details,
                    opt => opt.MapFrom(geoEvent => geoEvent.Details))
                .ForMember(geoEventVm => geoEventVm.Id,
                    opt => opt.MapFrom(geoEvent => geoEvent.Id))
                .ForMember(geoEventVm => geoEventVm.CreationDate,
                    opt => opt.MapFrom(geoEvent => geoEvent.CreationDate))
                .ForMember(geoEventVm => geoEventVm.EditDate,
                    opt => opt.MapFrom(geoEvent => geoEvent.EditDate));
        }
    }
}
