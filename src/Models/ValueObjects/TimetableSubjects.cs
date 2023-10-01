namespace TimeasyAPI.src.Models.ValueObjects
{
    public class TimetableSubjects
    {

        public Guid CourseId { get; set; }
        public Guid TimetableId { get; set; }
        public Guid SubjectId { get; set; }


        public bool IsDivided { get; set; } = false;
        public int DividedCount { get; set; }
        public int StudentsCount { get; set; }

        // EF Relations
    
        public Course Course { get; set; }
        public Subject Subject { get; set; }
        public Timetable Timetable { get; set; }
    }
}
