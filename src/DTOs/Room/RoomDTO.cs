namespace TimeasyAPI.src.DTOs.Room
{
    public class RoomDTO
    {
        public Guid Id { get;set; }
        public string Name { get; set; }
        public string Block { get; set; }
        public int Capacity { get; set; }
        public string? Type { get; set; }

        public Guid? roomTypeId { get; set; }
    }
}
