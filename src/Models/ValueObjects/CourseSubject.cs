namespace TimeasyAPI.src.Models.ValueObjects
{
    public class CourseSubject
    {
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }

        public int WeeklyClassCount { get; set; }
    }
}
