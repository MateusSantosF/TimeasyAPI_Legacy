namespace TimeasyAPI.src.Models.ValueObjects
{
    public class TimetableSubjects
    {

        public bool IsDivided { get; set; } = false;
        public int DividedCount { get; set; }
        public int StudentsCount { get; set; }

        // EF Relations
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }
        public Guid TimetableId { get; set; }
        public Timetable Timetable { get; set; }
    }
}
