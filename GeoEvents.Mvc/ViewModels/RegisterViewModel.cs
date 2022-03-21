using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GeoEvents.Mvc.ViewModels
{
    public class RegisterViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }

        [Display(Name = "День рождения")]
        public string DateOfBirth { get; set; }

        [Required]
        [EmailAddress]
        //remote - для проверки есть ли уже данный email
        [Remote(action: "IsEmailInUse", controller: "Account")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтвердите пароль")]
        [Compare("Password",
            ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Город")]
        public string? City { get; set; }
        [Display(Name = "Пол")]
        public string Sex { get; set; }
    }
}
