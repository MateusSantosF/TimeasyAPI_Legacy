namespace TimeasyAPI.src.Models
{
    public class Room : BaseEntity
    {
        public string Name { get; set; }   
        public string Block { get; set; }

        public int Capacity { get; set; }
        public RoomType Type { get; set; }

        // EF Relations
        public List<Timetable> Timetables { get; } = new();
        public Guid RoomTypeId { get; set; }
    }
}
