using TimeasyAPI.src.DTOs.Teacher.Requests;
using TimeasyAPI.src.DTOs.Timetable;
using TimeasyAPI.src.DTOs.Timetable.Requests;
using TimeasyAPI.src.Models.UI;

namespace TimeasyAPI.src.Services.Interfaces
{
    public interface ITimetableServices
    {
        Task<PagedResult<TimetableDTO>> GetAllAsync(int page, int pageSize);

        Task RemoveByIdAsync(Guid id);

        Task<TimetableDTO> CreateAsync(CreateTimetableRequest request, Guid instituteId);

        Task UpdateAsync(UpdateTeacherRequest request);
    }
}
