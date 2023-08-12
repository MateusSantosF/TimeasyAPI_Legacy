namespace TimeasyAPI.src.Models.ValueObjects
{
    public class TimetableSubjects
    {
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }
        public Guid TimetableId { get; set; }
        public Timetable Timetable { get; set; }
        public int StudentAmount { get; set; }
    }
}
