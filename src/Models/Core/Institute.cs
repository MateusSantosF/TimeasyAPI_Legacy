using System.ComponentModel.DataAnnotations;
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
        public ICollection<Course> Courses { get; set; }
        public ICollection<Timetable> Timetables { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
