using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TimeasyAPI.src.Models.ValueObjects;
using TimeasyAPI.src.Models.ValueObjects.Enums;

namespace TimeasyAPI.src.Models
{
    public class Subject : BaseEntity
    {

        [Required(ErrorMessage = "Acronym is required.")]
        [MaxLength(10, ErrorMessage = "Acronym must be at most 10 characters.")]
        public string Acronym { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100, ErrorMessage = "Name must be at most 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Complexity is required.")]
        public SubjectComplexity Complexity { get; set; }

        [Required(ErrorMessage = "RoomTypeNeeded is required.")]
        public RoomType RoomTypeNeeded { get; set; }


        //EF Relations
        public ICollection<CourseSubject> CourseSubject { get; set; }
        public ICollection<TimetableSubjects> TimetableSubjects { get; set; }

        public Guid RoomTypeId { get; set; }
    }
}
