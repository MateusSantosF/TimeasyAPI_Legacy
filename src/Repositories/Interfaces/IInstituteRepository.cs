using TimeasyAPI.src.Models;

namespace TimeasyAPI.src.Repositories.Interfaces
{
    public interface IInstituteRepository : IGenericRepository<Institute>
    {
        Task<Institute?> GetByIdWithIntervalsAsync(Guid id);
    }
}
