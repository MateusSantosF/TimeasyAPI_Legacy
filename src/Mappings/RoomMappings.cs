using TimeasyAPI.src.DTOs.Room;
using TimeasyAPI.src.DTOs.Room.Request;
using TimeasyAPI.src.Models;
using TimeasyAPI.src.Models.UI;

namespace TimeasyAPI.src.Mappings
{
    public static class RoomMappings
    {

        public static RoomDTO EntitieToMap(this Room room)
        {
            return new RoomDTO
            {
                Id = room.Id.ToString(),
                Name = room.Name,
                Block = room.Block,
                Capacity = room.Capacity,
                Type = room?.Type.Name
            };
        }

        public static Room MapToEntitie(this CreateRoomRequest room)
        {
            return new Room
            {
                Name = room.Name,
                Block = room.Block,
                Capacity = room.Capacity,
                RoomTypeId = Guid.Parse(room.TypeId)
            };
        }

    }
}
