using TimeasyAPI.src.DTOs.FPA.Schedule;
using TimeasyAPI.src.DTOs.Subject;

namespace TimeasyAPI.src.DTOs.FPA
{
    public class FPADTO
    {
        public Guid Id;

        public List<SubjectDTO> Subjects { get; set; }
        public List<ScheduleDTO> Schedules { get; set; }
        public Guid TimetableId { get; set; }

        public string Registration { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }
    }
}
