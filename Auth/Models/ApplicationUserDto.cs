using System.ComponentModel.DataAnnotations;

namespace Auth.Models
{
    public class ApplicationUserDto
    {
        public string? Email { get; set; } = "";
        public string? Password { get; set; } = "";
        public string? InitialPassword { get; set; } // Не захешированный пароль для отображения
        public string? FirtsName { get; set; } = "";
        public string? PhoneNumber { get; set; } = "";
        public string? LastName { get; set; } = "";
        [MaxLength(50)]
        public string? Patronymic { get; set; } = "";
        public string? Address { get; set; } = "";
        [MaxLength(10)]
        public string? Gender { get; set; } = "";
        [MaxLength(100)]
        public string? WorkPlace { get; set; } = "";
        [MaxLength(100)]
        public string? Specialization { get; set; } = "";
        public DateTime? DateOfBirth { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; } = "";
        public DateTime? DateOfExp { get; set; }
        public DateTime? CreatedAt { get; set; }
        public IFormFile? ImageFile { get; set; }
        public AppointmentSlot? AppointmentSlot { get; set; }
        public int RatingSum { get; set; } // Сумма рейтинга комментариев
        public int RatingCount { get; set; }
    }
}
