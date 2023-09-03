using TimeasyAPI.src.Models.ValueObjects.Enums;

namespace TimeasyAPI.src.DTOs.Teacher
{
    public class TeacherDTO
    {
        public Guid Id { get; set; }
        public Guid InstituteId { get; set; }
        public string Registration { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public AcademicDegree AcademicDegree { get; set; }
        public string BirthDate { get; set; }
        public int TeachingHours { get; set; }
        public string IfspServiceTime { get; set; }
        public string CampusServiceTime { get; set; }
    }
}
