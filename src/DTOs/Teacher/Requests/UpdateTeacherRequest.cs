using System.ComponentModel.DataAnnotations;

namespace TimeasyAPI.src.DTOs.Teacher.Requests
{
    public class UpdateTeacherRequest
    {
        [Required]
        public Guid TeacherId { get; set; }

        public string? Registration { get; set; }

        [MaxLength(100, ErrorMessage = "FullName must be at most 100 characters.")]
        public string? FullName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [MaxLength(100, ErrorMessage = "Email must be at most 100 characters.")]
        public string? Email { get; set; }

        public string? AcademicDegree { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateOnly? BirthDate { get; set; }

        public int? TeachingHours { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Invalid date and time format.")]
        public DateOnly? IfspServiceTime { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Invalid date and time format.")]
        public DateOnly? CampusServiceTime { get; set; }
    }
}
