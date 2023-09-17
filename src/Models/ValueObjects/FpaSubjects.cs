namespace TimeasyAPI.src.Models.ValueObjects
{
    public class FpaSubjects
    {
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }

    }
}
