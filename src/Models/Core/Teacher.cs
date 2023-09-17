using TimeasyAPI.src.Models.ValueObjects.Enums;

namespace TimeasyAPI.src.Models
{
    public class Teacher : BaseEntity
    {
        public string Registration { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public AcademicDegree AcademicDegree { get; set; }
        public int TeachingHours { get; set; }
        public DateOnly BirthDate { get; set; }
        public DateOnly IfspServiceTime { get; set; }
        public DateOnly CampusServiceTime { get; set; }

        // EF Relations
        public Guid InstituteId { get; set; }
        public Institute Institute { get; set; }
        public List<FPA> FPA { get; } = new();
        public List<Timetable> Timetables { get; } = new();
    }
}
