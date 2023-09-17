using System.ComponentModel.DataAnnotations;

namespace TimeasyAPI.src.DTOs.FPA.requests
{
    public class FpaSubjectDTO
    {
        [Required]
        public Guid SubjectId { get; set; }

        [Required]
        public Guid CourseId { get; set; }
    }
}
