using System.ComponentModel.DataAnnotations;

namespace GeoEvents.Mvc.ViewModels
{
    public class CreateConsideredGeoEvent
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
    }
}
