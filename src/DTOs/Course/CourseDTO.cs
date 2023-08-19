using TimeasyAPI.src.DTOs.Course.CourseSubject;
using TimeasyAPI.src.Models.ValueObjects.Enums;

namespace TimeasyAPI.src.DTOs.Courses
{
    public class CourseDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int PeriodAmount { get; set; }

        public Turn Turn { get; set; }

        public PeriodType Period { get; set; }

        public ICollection<CourseSubjectDTO> Subjects { get; set; }
    }
}
