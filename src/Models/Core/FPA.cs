using TimeasyAPI.src.Models.Core;
using TimeasyAPI.src.Models.ValueObjects;
using TimeasyAPI.src.Models.ValueObjects.Enums;

namespace TimeasyAPI.src.Models
{
    public class FPA : BaseEntity
    {

        public FPA()
        {
            Status = FPAStatus.NOT_FILLED;    
        }

        public FPAStatus Status { get; set; }
        public List<Schedule> Schedules { get; } = new();

        //EF Relations
        public List<FpaSubjects> Subjects { get; } = new();
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public Guid TimetableId { get; set; }
        public Timetable Timetable { get; set; }
    }
}
