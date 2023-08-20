using TimeasyAPI.src.Models.ValueObjects;

namespace TimeasyAPI.src.DTOs.Timetable
{
    public class TimetableCourseDTO
    {
        public Guid CourseId {get;set;}

        public WeekdayAvailability CourseOperatingDays { get;set;}  
    }
}
