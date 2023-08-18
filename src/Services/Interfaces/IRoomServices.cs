using TimeasyAPI.src.DTOs.Room;
using TimeasyAPI.src.DTOs.Room.Request;
using TimeasyAPI.src.Models.UI;

namespace TimeasyAPI.src.Services.Interfaces
{
    public interface IRoomServices
    {
        Task<PagedResult<RoomDTO>> GetAllAsync(int page, int pageSize);

        Task RemoveByIdAsync(string id);

        Task<RoomDTO> CreateAsync(CreateRoomRequest request);
    }
}
