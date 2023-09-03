namespace TimeasyAPI.src.DTOs.Room.Response
{
    public class CreateRoomResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Block { get; set; }
        public int Capacity { get; set; }

        public Guid roomTypeId { get; set; }
    }
}
