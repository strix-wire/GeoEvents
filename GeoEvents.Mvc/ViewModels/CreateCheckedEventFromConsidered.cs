using AutoMapper;
using GeoEvents.Application.CheckedGeoEvents.Commands.CreateGeoEvent;
using GeoEvents.Application.Common.Mappings;
using GeoEvents.Application.ConsideredGeoEvents.Queries.GetGeoEventDetails;

namespace GeoEvents.Mvc.ViewModels
{
    public class CreateCheckedEventFromConsidered : IMapWith<ConsideredGeoEventDetailsVm>, IMapWith<CreateCheckedGeoEventCommand>
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public void Mapping(Profile profile)
        {
            //profile.CreateMap<ConsideredGeoEventDetailsVm, CreateCheckedEventFromConsidered>()
            profile.CreateMap<ConsideredGeoEventDetailsVm, CreateCheckedEventFromConsidered>()
                //.ForMember(geoEventVm => geoEventVm.UserId,
                //    opt => opt.MapFrom(geoEvent => geoEvent.UserId))
                .ForMember(geoEventVm => geoEventVm.Title,
                    opt => opt.MapFrom(geoEvent => geoEvent.Title))
                .ForMember(geoEventVm => geoEventVm.Details,
                    opt => opt.MapFrom(geoEvent => geoEvent.Details))
                .ForMember(geoEventVm => geoEventVm.Latitude,
                    opt => opt.MapFrom(geoEvent => geoEvent.Latitude))
                .ForMember(geoEventVm => geoEventVm.Longitude,
                    opt => opt.MapFrom(geoEvent => geoEvent.Longitude));

            //profile.CreateMap<CreateCheckedGeoEventCommand, CreateCheckedEventFromConsidered>()
            profile.CreateMap<CreateCheckedEventFromConsidered, CreateCheckedGeoEventCommand>()
                //.ForMember(geoEventVm => geoEventVm.UserId,
                //    opt => opt.MapFrom(geoEvent => geoEvent.UserId))
                .ForMember(geoEventVm => geoEventVm.Title,
                    opt => opt.MapFrom(geoEvent => geoEvent.Title))
                .ForMember(geoEventVm => geoEventVm.Details,
                    opt => opt.MapFrom(geoEvent => geoEvent.Details))
                .ForMember(geoEventVm => geoEventVm.Latitude,
                    opt => opt.MapFrom(geoEvent => geoEvent.Latitude))
                .ForMember(geoEventVm => geoEventVm.Longitude,
                    opt => opt.MapFrom(geoEvent => geoEvent.Longitude));
        }
    }
}
