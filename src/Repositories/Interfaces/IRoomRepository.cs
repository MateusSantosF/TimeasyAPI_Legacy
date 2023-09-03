using System.Linq.Expressions;
using TimeasyAPI.src.Models;
using TimeasyAPI.src.Models.UI;

namespace TimeasyAPI.src.Repositories.Interfaces
{
    public interface IRoomRepository : IGenericRepository<Room>
    {
        Task<PagedResult<Room>> GetAllWithTypeAsync(int page, int pageSize);

        Task<PagedResult<Room>> GetAllWithTypeAsync(int page, int pageSize, Expression<Func<Room, bool>> search);

        Task<List<Room>> GetAllRoomsById(List<Guid> roomsId);
    }
}
