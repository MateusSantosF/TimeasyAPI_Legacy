using TimeasyAPI.src.Models.ValueObjects;
using TimeasyAPI.src.Models.ValueObjects.Enums;

namespace TimeasyAPI.src.Models
{
    public class Timetable: BaseEntity
    {
        public string Name { get; set; }

        public DateOnly CreateAt { get; set; }

        public DateOnly? EndedAt { get; set; }

        // EF Relations
        public TimetableStatus Status { get; set; }
        public Guid InstituteId { get; set; }
        public Institute Institute { get; set; }
        public List<TimetableSubjects> TimetableSubjects { get; } = new();
        public List<TimetableCourses> TimetableCourses { get; } = new();
        public List<Room> Rooms { get; } = new();
        public List<FPA> FPAs { get; } = new();
        public List<Teacher> Teachers { get; } = new();
    }
}
