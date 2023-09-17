using TimeasyAPI.src.Models.Core;

namespace TimeasyAPI.src.Repositories.Interfaces
{
    public interface IScheduleRepository : IGenericRepository<Schedule>
    {
        Task AddRange(List<Schedule> intervals);
    }
}
