using TimeasyAPI.src.Models.ValueObjects;

namespace TimeasyAPI.src.DTOs.Timetable.Requests
{
    public class CreateTimetableCourseDTO
    {
        public Guid CourseId { get; set; }

        public WeekdayAvailability CourseOperatingDays { get; set; }
    }
}
