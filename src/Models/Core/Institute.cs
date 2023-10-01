using TimeasyAPI.src.Models.Core;

namespace TimeasyAPI.src.Models
{
    public class Institute : BaseEntity
    {

        public string Name { get; set; }   
        public string OpenHour { get; set; }
        public string CloseHour { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }

        // EF Relations
        public List<Interval> Intervals { get; set; } = new();
        public List<Course> Courses { get; set; } = new();
        public List<Timetable> Timetables { get; set; } = new();
        public List<Teacher> Teachers { get; set; } = new();
        public List<User> Users { get; set; } = new();
    }
}
