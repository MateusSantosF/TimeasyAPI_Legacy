using TimeasyAPI.src.DTOs.Interval;

namespace TimeasyAPI.src.DTOs.Institute
{
    public class InstituteDTO
    {
        public Guid Id { get; set; }  
        public string Name { get; set; }
        public string OpenHour { get; set; }
        public string CloseHour { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }

        public List<IntervalDTO> Intervals { get; set; }
    }
}
