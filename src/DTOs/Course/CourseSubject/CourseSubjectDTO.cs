using System.ComponentModel.DataAnnotations;

namespace TimeasyAPI.src.DTOs.Course.CourseSubject
{
    public class CourseSubjectDTO
    {
        public Guid SubjectId { get; set; }

        public string SubjectName { get; set; } = string.Empty;

        [Required]
        [Range(1, 100, ErrorMessage = "WeeklyClassCount must be greater than 0.")]
        public int WeeklyClassCount { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "WeeklyClassCount must be greater than 0.")]
        public int Period { get; set; }
    }
}
