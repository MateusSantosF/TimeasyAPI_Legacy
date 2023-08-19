using TimeasyAPI.src.DTOs.Teacher;
using TimeasyAPI.src.DTOs.Teacher.Requests;
using TimeasyAPI.src.Models.UI;

namespace TimeasyAPI.src.Services.Interfaces
{
    public interface ITeacherServices
    {
        Task<PagedResult<TeacherDTO>> GetAllAsync(int page, int pageSize);

        Task RemoveByIdAsync(Guid id);

        Task<TeacherDTO> CreateAsync(CreateTeacherRequest request, Guid instituteId);

        Task UpdateAsync(UpdateTeacherRequest request);
    }
}
