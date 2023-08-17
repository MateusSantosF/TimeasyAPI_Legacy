using TimeasyAPI.src.Models;

namespace TimeasyAPI.src.Repositories.Interfaces
{
    public interface IIntervalRepository : IGenericRepository<Interval>
    {
        Task AddRange(List<Interval> intervals);
    }
}
