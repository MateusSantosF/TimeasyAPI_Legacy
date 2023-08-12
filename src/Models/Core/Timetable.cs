using TimeasyAPI.src.Models.ValueObjects;

namespace TimeasyAPI.src.Models
{
    public class Timetable: BaseEntity
    {
        // EF Relations
        public Guid InstituteId { get; set; }
        public Institute Institute { get; set; }
        public ICollection<TimetableSubjects> TimetableSubjects { get; set; }
        public ICollection<TimetableCourses> TimetableCourses { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<FPA> FPAs { get; set; }
    }
}
