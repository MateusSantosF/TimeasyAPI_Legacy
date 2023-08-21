namespace TimeasyAPI.src.DTOs.Timetable.Requests
{
    public class GetTimetableSubject
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int StudentsCount { get; set; }

        public bool? IsDivided { get; set; }

        public int? DividedCount { get; set; }
    }
}
