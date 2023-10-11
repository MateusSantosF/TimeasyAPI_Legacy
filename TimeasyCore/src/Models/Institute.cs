namespace TimeasyCore.src.Models
{
    public class Institute
    {
        public Guid Id { get; set; }
        public TimeOnly OpenHour { get; set; }
        public TimeOnly CloseHour { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }

        public List<Interval> Intervals { get; set; }
    }
}
