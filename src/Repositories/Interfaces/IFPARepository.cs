using TimeasyAPI.src.Models;

namespace TimeasyAPI.src.Repositories.Interfaces
{
    public interface IFPARepository  : IGenericRepository<FPA>
    {
        Task AddRange(List<FPA> fpas);
    }
}
