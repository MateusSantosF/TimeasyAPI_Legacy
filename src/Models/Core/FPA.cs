using TimeasyAPI.src.Helpers;
using TimeasyAPI.src.Models.ValueObjects.Enums;

namespace TimeasyAPI.src.Models
{
    public class FPA
    {
        public FPA()
        {
            Code = RandomNumberGenerator.GenerateRandomNumber(6);
        }
        public string Code { get; set; }
        public FPAStatus Status { get; set; }
        public List<Interval> Schedules { get; set; }

        //EF Relations
        public ICollection<Subject> Subjects { get; set; }
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public Timetable Timetable { get; set; }
    }
}
