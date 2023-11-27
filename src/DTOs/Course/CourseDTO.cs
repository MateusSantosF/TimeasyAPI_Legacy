using TimeasyAPI.src.DTOs.Course.CourseSubject;

namespace TimeasyAPI.src.DTOs.Courses
{
    public class CourseDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int PeriodAmount { get; set; }

        public string Turn { get; set; }

        public string Period { get; set; }

        public ICollection<CourseSubjectDTO> Subjects { get; set; }
    }
}
