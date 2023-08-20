using TimeasyAPI.src.Models.ValueObjects.Enums;

namespace TimeasyAPI.src.DTOs.Timetable
{
    public class TimetableDTO
    {

        public Guid Id { get; set; }
        public string Name { get; set; }

        public TimetableStatus Status { get; set; }

        public DateOnly CreateAt { get; set; }

        public DateOnly? EndedAt { get; set; }


        public IEnumerable<Guid> Rooms { get; set; }    
        public IEnumerable<TimetableSubjectDTO> Subjects { get; set; }
        public IEnumerable<TimetableCourseDTO> Courses { get; set; }
    }
}
