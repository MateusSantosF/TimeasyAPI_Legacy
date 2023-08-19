using TimeasyAPI.src.Models;
using TimeasyAPI.src.Models.UI;

namespace TimeasyAPI.src.Repositories.Interfaces
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<PagedResult<Course>> GetAllWithSubjectsAsync(int page, int pageSize);
    }
}
