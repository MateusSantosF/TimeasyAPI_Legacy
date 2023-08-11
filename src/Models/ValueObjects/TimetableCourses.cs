namespace TimeasyAPI.src.Models.ValueObjects
{
    public class TimetableCourses
    {
        public Guid CourseId { get; set; }
        public Course Course {get;set;}
        public Guid TimetableId { get; set; }
        public Timetable Timetable { get; set; }

        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
    }
}
