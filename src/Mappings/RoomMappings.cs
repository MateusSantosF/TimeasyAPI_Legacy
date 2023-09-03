using TimeasyAPI.Controllers.Middlewares.Exceptions;
using TimeasyAPI.src.DTOs.Room;
using TimeasyAPI.src.DTOs.Room.Request;
using TimeasyAPI.src.DTOs.Room.Response;
using TimeasyAPI.src.Models;

namespace TimeasyAPI.src.Mappings
{
    public static class RoomMappings
    {

        public static RoomDTO EntitieToMap(this Room room)
        {
            return new RoomDTO
            {
                Id = room.Id,
                Name = room.Name,
                Block = room.Block,
                Capacity = room.Capacity,
                Type = room.Type is null ? null : room.Type.Name,
                roomTypeId = room.Type is null ? null : room.Type.Id
            };
        }




        public static Room MapToEntitie(this CreateRoomRequest room)
        {
            try
            {
                return new Room
                {
                    Name = room.Name,
                    Block = room.Block,
                    Capacity = room.Capacity,
                    RoomTypeId = room.RoomTypeId
                };
            }catch(Exception err)
            {
                throw new AppException(err.Message);
            }
           
        }

    }
}
