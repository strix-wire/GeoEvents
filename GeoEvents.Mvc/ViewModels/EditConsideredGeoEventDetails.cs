using AutoMapper;
using GeoEvents.Application.Common.Mappings;
using GeoEvents.Application.ConsideredGeoEvents.Queries.GetGeoEventDetails;
using System.ComponentModel.DataAnnotations;

namespace GeoEvents.Mvc.ViewModels
{
    public class EditConsideredGeoEventDetails : IMapWith<ConsideredGeoEventDetailsVm>
    {
        [Required(ErrorMessage = "Ввод названия события является обязательным")]
        [Display(Name = "Название")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Ввод описания события является обязательным")]
        [Display(Name = "Описание")]
        public string Details { get; set; }

        [Required(ErrorMessage = "Ввод координаты широты события является обязательным")]
        [Display(Name = "Широта")]
        [Range(float.MinValue, float.MaxValue, ErrorMessage = "Широта должна быть дробным значением")]
        public string Latitude { get; set; }
        
        [Required(ErrorMessage = "Ввод координаты долготы события является обязательным")]
        [Display(Name = "Долгота")]
        [Range(float.MinValue, float.MaxValue, ErrorMessage = "Долгота должна быть дробным значением")]
        public string Longitude { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ConsideredGeoEventDetailsVm, EditConsideredGeoEventDetails>()
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
