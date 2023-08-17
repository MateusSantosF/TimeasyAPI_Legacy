using TimeasyAPI.src.DTOs.Institute.Request;

namespace TimeasyAPI.src.Services.Interfaces
{
    public interface IIntervalServices
    {

        Task AddIntervalsAsync(AddIntervalsRequest request);

        Task DeleteAsync(string id);
    }
}
