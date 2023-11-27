using System.ComponentModel.DataAnnotations;
using TimeasyAPI.src.DTOs.Course.CourseSubject;

namespace TimeasyAPI.src.DTOs.Course.Requests
{
    public class CreateCourseRequest
    {
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100, ErrorMessage = "Name must be at most 100 characters.")]
        public string Name { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "PeriodAmount must be greater than 0.")]
        public int PeriodAmount { get; set; }

        [Required(ErrorMessage = "Turn is required.")]
        public string Turn { get; set; }

        [Required(ErrorMessage = "Period is required.")]
        public string Period { get; set; }

        [Required(ErrorMessage = "Subjects is required.")]
        public ICollection<CourseSubjectDTO> Subjects { get; set; }

    }
}
