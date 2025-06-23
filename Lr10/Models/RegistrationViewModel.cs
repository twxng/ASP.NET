using System.ComponentModel.DataAnnotations;

namespace Lr10.Models
{
    public class RegistrationViewModel : IValidatableObject
    {
        [Required(ErrorMessage = "Введіть ім'я та прізвище")]
        [Display(Name = "Ім'я та прізвище")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введіть Email")]
        [EmailAddress(ErrorMessage = "Некоректний Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Виберіть бажану дату консультації")]
        [DataType(DataType.Date)]
        [Display(Name = "Бажана дата консультації")]
        public DateTime? ConsultationDate { get; set; }

        [Required(ErrorMessage = "Оберіть продукт")]
        [Display(Name = "Продукт")]
        public string Product { get; set; } = string.Empty;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ConsultationDate.HasValue)
            {
                var date = ConsultationDate.Value;
                if (date <= DateTime.Today)
                {
                    yield return new ValidationResult("Дата має бути у майбутньому", new[] { nameof(ConsultationDate) });
                }
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    yield return new ValidationResult("Дата не може бути на вихідний день", new[] { nameof(ConsultationDate) });
                }
                if (Product == "Основи" && date.DayOfWeek == DayOfWeek.Monday)
                {
                    yield return new ValidationResult("Консультація по 'Основи' не може бути у понеділок", new[] { nameof(ConsultationDate) });
                }
            }
        }
    }
} 