using TimeasyAPI.src.DTOs.RoomType;
using TimeasyAPI.src.Models.UI;

namespace TimeasyAPI.src.Services.Interfaces
{
    public interface IRoomTypeServices
    {

        Task<PagedResult<RoomTypeDTO>> GetAllAsync(int page, int pageSize);

        Task DeleteAsync(Guid id);
        Task<RoomTypeDTO> CreateAsync(CreateRoomTypeRequest request);
    }
}
