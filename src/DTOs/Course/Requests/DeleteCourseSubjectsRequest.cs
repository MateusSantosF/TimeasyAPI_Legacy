using System.ComponentModel.DataAnnotations;

namespace TimeasyAPI.src.DTOs.Course.Requests
{
    public class DeleteCourseSubjectsRequest
    {
        [Required]
        public Guid CourseId { get; set; }

        [Required]
        public List<Guid> Subjects { get; set; }
    }
}
