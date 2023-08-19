using TimeasyAPI.src.DTOs.RoomType;
using TimeasyAPI.src.DTOs.Subject;
using TimeasyAPI.src.DTOs.Subject.Requests;
using TimeasyAPI.src.Models.UI;

namespace TimeasyAPI.src.Services.Interfaces
{
    public interface ISubjectService
    {

        Task<PagedResult<SubjectDTO>> GetAllAsync(int page, int pageSize);
        Task UpdateAsync(UpdateSubjectRequest request);
        Task DeleteByIdAsync(Guid id);
        Task<SubjectDTO> CreateAsync(CreateSubjectRequest request);
    }
}
