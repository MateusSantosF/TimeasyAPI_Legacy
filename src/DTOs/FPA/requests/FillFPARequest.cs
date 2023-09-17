using TimeasyAPI.src.DTOs.FPA.Schedule;


namespace TimeasyAPI.src.DTOs.FPA.requests
{
    public class FillFPARequest
    {
        public List<FpaSubjectDTO> Subjects { get; set; }
        public List<ScheduleDTO> Schedules { get; set; }
        public Guid TimetableId { get; set; }

        public string Registration { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }
    }
}
