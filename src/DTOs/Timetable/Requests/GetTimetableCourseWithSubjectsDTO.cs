using TimeasyAPI.src.DTOs.Course.CourseSubject;
using TimeasyAPI.src.Models.ValueObjects.Enums;

namespace TimeasyAPI.src.DTOs.Timetable.Requests
{
    public class GetTimetableCourseWithSubjectsDTO
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public int PeriodAmount { get; set; }

        public Turn Turn { get; set; }

        public PeriodType Period { get; set; }

        public ICollection<GetTimetableSubject> Subjects { get; set; }
    }
}
