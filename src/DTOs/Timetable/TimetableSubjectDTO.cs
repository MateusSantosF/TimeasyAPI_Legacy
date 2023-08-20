using System.ComponentModel.DataAnnotations;

namespace TimeasyAPI.src.DTOs.Timetable
{
    public class TimetableSubjectDTO
    {
        [Required]
        public Guid SubjectId { get; set; }

        [Required]
        public Guid CourseId { get; set; }

        [Required]
        public int StudentsCount { get; set; }

        public bool? IsDivided { get; set; }

        public int? DividedCount { get; set; }


    }
}
