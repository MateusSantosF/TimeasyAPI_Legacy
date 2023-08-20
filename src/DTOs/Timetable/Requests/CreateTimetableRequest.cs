using System.ComponentModel.DataAnnotations;

namespace TimeasyAPI.src.DTOs.Timetable.Requests
{
    public class CreateTimetableRequest
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Name must be at most 100 characters.")]
        public string Name { get; set; }

        [Required]
        [MinLength(1)]
        public List<TimetableSubjectDTO> Subjects { get; set; }

        [Required]
        [MinLength(1)]
        public List<TimetableCourseDTO> Courses { get; set; }

        [Required]
        [MinLength(1)]
        public List<Guid> Rooms { get; set; }

    }
}
