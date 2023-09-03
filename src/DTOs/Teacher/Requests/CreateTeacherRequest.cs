using System.ComponentModel.DataAnnotations;

namespace TimeasyAPI.src.DTOs.Teacher.Requests
{
    public class CreateTeacherRequest
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
        public string AcademicDegree { get; set; }

        [Required(ErrorMessage = "BirthDate is required.")]
        public string BirthDate { get; set; }

        [Required(ErrorMessage = "TeachingHours is required.")]
        public int TeachingHours { get; set; }

        [Required(ErrorMessage = "IfspServiceTime is required.")]
        public string IfspServiceTime { get; set; }

        [Required(ErrorMessage = "CampusServiceTime is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date and time format.")]
        public string CampusServiceTime { get; set; }
    }
}
