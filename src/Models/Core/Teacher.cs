using System.ComponentModel.DataAnnotations;
using TimeasyAPI.src.Models.ValueObjects.Enums;

namespace TimeasyAPI.src.Models
{
    public class Teacher : BaseEntity
    {
        [Required(ErrorMessage = "Registration is required.")]
        public string Registration { get; set; }

        [Required(ErrorMessage = "FullName is required.")]
        [MaxLength(100, ErrorMessage = "FullName must be at most 100 characters.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [MaxLength(100, ErrorMessage = "Email must be at most 100 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "AcademicDegree is required.")]
        public AcademicDegree AcademicDegree { get; set; }

        [Required(ErrorMessage = "BirthDate is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "TeachingHours is required.")]
        [DataType(DataType.Time, ErrorMessage = "Invalid time format.")]
        public TimeOnly TeachingHours { get; set; }

        [Required(ErrorMessage = "IfspServiceTime is required.")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid date and time format.")]
        public DateTime IfspServiceTime { get; set; }

        [Required(ErrorMessage = "CampusServiceTime is required.")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid date and time format.")]
        public DateTime CampusServiceTime { get; set; }


        // EF Relations
        public Guid InstituteId { get; set; }
        public Institute Institute { get; set; }
        public ICollection<FPA> FPA { get; set; }
    }
}
