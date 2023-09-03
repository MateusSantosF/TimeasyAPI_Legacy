using TimeasyAPI.src.Models.ValueObjects.Enums;

namespace TimeasyAPI.src.DTOs.RoomType
{
    public class RoomTypeDTO
    {

        public Guid Id { get;set; }

        public string Name { get; set; }

        public bool IsComputerLab { get; set; }

        public OperationalSystem? OperationalSystem { get; set; }
    }
}
