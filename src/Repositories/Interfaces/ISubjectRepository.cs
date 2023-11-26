using System.Linq.Expressions;
using TimeasyAPI.src.Models;
using TimeasyAPI.src.Models.UI;

namespace TimeasyAPI.src.Repositories.Interfaces
{
    public interface ISubjectRepository : IGenericRepository<Subject>
    {

        Task<List<Subject>> GetAllById(List<Guid> subjectsId);

        Task<bool> CheckIfExistsAsync(List<Guid> subjectsId);
        Task<PagedResult<Subject>> GetAllWithRoomTypeAsync(int page, int pageSize);
        Task<PagedResult<Subject>> GetAllWithRoomTypeAsync(int page, int pageSize, Expression<Func<Subject, bool>> search);

    }
}
