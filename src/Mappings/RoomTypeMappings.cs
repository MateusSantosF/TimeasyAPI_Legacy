using TimeasyAPI.src.DTOs.RoomType;
using TimeasyAPI.src.Models;
using TimeasyAPI.src.Models.ValueObjects.Enums;

namespace TimeasyAPI.src.Mappings
{
    public static class RoomTypeMappings
    {

        public static RoomTypeDTO EntitieToMap(this RoomType room)
        {
            return new RoomTypeDTO
            {

                Id = room.Id.ToString(),
                Name = room.Name,
                IsComputerLab = room.IsComputerLab,
                OperationalSystem = room.OperationalSystem.ToString()
            };
        }

        public static RoomType MapToEntitie(this CreateRoomTypeRequest room)
        {
            return new RoomType
            {
                Name = room.Name,
                IsComputerLab = room.IsComputerLab,
                OperationalSystem = Enum.Parse<OperationalSystem>(room.OperationalSystem, true)
            };
        }
    }
}
