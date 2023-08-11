using System.ComponentModel.DataAnnotations;
using TimeasyAPI.src.Models.ValueObjects;
using TimeasyAPI.src.Models.ValueObjects.Enums;

namespace TimeasyAPI.src.Models
{
    public class Course : BaseEntity
    {

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100, ErrorMessage = "Name must be at most 100 characters.")]
        public string Name { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "PeriodAmount must be greater than 0.")]
        public int PeriodAmount { get; set; }

        [Required(ErrorMessage = "Turn is required.")]
        public Turn Turn { get; set; }

        [Required(ErrorMessage = "Period is required.")]
        public PeriodType Period { get; set; }

        // EF Relation
        public Guid InstituteId { get; set; }
        public Institute Institute { get; set; }
        public ICollection<CourseSubject> CourseSubject { get; set; }

        public ICollection<TimetableCourses> TimetableCourses { get; set; }

    }
}
