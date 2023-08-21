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
        public List<CourseSubject> CourseSubject { get; } = new();
        public List<TimetableSubjects> TimetableSubjects { get; } = new();

        public Guid RoomTypeId { get; set; }
    }
}
