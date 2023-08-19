namespace TimeasyAPI.src.DTOs.Subject
{
    public class SubjectDTO
    {
        public string Id {  get; set; } 

        public string Acronym { get; set; }

        public string Name { get; set; }

        public string Complexity { get; set; }

        public string? RoomType { get; set; }

        public string RoomTypeId { get; set; }
    }
}
