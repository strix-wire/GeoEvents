using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GeoEvents.Mvc.ViewModels
{
    public class RegisterViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Ввод имени является обязательным")]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ввод фамилии является обязательным")]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Display(Name = "Отчество")]
        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "Ввод email является обязательным")]
        [EmailAddress]
        //remote - для проверки есть ли уже данный email
        [Remote(action: "IsEmailInUse", controller: "Account")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ввод пароля является обязательным")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Ввод повтора пароля является обязательным")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердите пароль")]
        [Compare("Password",
            ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Город")]
        public string? City { get; set; }
    }
}
