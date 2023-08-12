using System.ComponentModel.DataAnnotations;
using TimeasyAPI.src.Models.Core;

namespace TimeasyAPI.src.Models
{
    public class Institute : BaseEntity
    {
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100, ErrorMessage = "Name must be at most 100 characters.")]
        public string Name { get; set; }

        [RegularExpression("^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "OpenHour must be in HH:mm format.")]
        public string OpenHour { get; set; }

        [RegularExpression("^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "CloseHour must be in HH:mm format.")]
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
