using TimeasyAPI.src.Models.ValueObjects;
using TimeasyAPI.src.Models.ValueObjects.Enums;

namespace TimeasyAPI.src.Models
{
    public class Subject : BaseEntity
    {
        public string Acronym { get; set; }
        public string Name { get; set; }
        public SubjectComplexity Complexity { get; set; }
        public RoomType RoomTypeNeeded { get; set; }

        //EF Relations
        public ICollection<CourseSubject> CourseSubject { get; set; }
        public ICollection<TimetableSubjects> TimetableSubjects { get; set; }

        public Guid RoomTypeId { get; set; }
    }
}
