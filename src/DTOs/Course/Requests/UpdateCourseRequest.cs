using System.ComponentModel.DataAnnotations;
using TimeasyAPI.src.DTOs.Course.CourseSubject;
using TimeasyAPI.src.Models.ValueObjects.Enums;

namespace TimeasyAPI.src.DTOs.Course.Requests
{
    public class UpdateCourseRequest
    {
        [Required]
        public Guid Id { get; set; }

        [MaxLength(100, ErrorMessage = "Name must be at most 100 characters.")]
        public string? Name { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "PeriodAmount must be greater than 0.")]
        public int? PeriodAmount { get; set; }

        public string? Turn { get; set; }

        public string? Period { get; set; }

        public ICollection<CourseSubjectDTO>? Subjects { get; set; }
    }
}
