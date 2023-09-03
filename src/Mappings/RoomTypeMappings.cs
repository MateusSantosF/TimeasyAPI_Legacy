using TimeasyAPI.src.DTOs.RoomType;
using TimeasyAPI.src.Models;

namespace TimeasyAPI.src.Mappings
{
    public static class RoomTypeMappings
    {

        public static RoomTypeDTO EntitieToMap(this RoomType room)
        {
            return new RoomTypeDTO
            {
                Id = room.Id,
                Name = room.Name,
                IsComputerLab = room.IsComputerLab,
                OperationalSystem = room?.OperationalSystem
            };
        }

        public static RoomType MapToEntitie(this CreateRoomTypeRequest room)
        {
            return new RoomType
            {
                Name = room.Name,
                IsComputerLab = room.IsComputerLab,
                OperationalSystem = room.OperationalSystem.HasValue ? room.OperationalSystem.Value : null
            };
        }
    }
}
