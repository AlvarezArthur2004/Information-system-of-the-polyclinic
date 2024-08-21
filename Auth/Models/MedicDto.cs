using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class MedicDto
    {

        [MaxLength(20)]
        public string ?PhoneNumber { get; set; } = "";

        [MaxLength(50)]
        public string FirstName { get; set; } = "";

        [MaxLength(50)]
        public string LastName { get; set; } = "";
        [Precision(16, 2)]
        public decimal? Price { get; set; }
        [MaxLength(50)]
        public string Patronymic { get; set; } = "";

        [MaxLength(10)]
        public string Gender { get; set; } = "";

        [MaxLength(100)]
        public string WorkPlace { get; set; } = "";
        [MaxLength(100)]
        public string Specialization { get; set; } = "";
        public DateTime DateOfBirth { get; set; }
        [MaxLength(100)]
        public string ?Email { get; set; } = "";
        public string ?Description { get; set; } = "";
        public IFormFile? ImageFile { get; set; }
    }
}
