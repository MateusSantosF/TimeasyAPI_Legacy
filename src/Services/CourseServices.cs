using TimeasyAPI.src.DTOs.Course.Requests;
using TimeasyAPI.src.DTOs.Courses;
using TimeasyAPI.src.Models.UI;
using TimeasyAPI.src.Repositories.Interfaces;
using TimeasyAPI.src.Services.Interfaces;

namespace TimeasyAPI.src.Services
{
    public class CourseServices : ICourseServices
    {

        private readonly ICourseRepository _courseRepository;


        public CourseServices(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public Task<CourseDTO> CreateAsync(CreateCourseRequest request, Guid instituteId)
        {
            return Task.FromResult(new CourseDTO());
        }

        public Task<PagedResult<CourseDTO>> GetAllAsync(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task RemoveByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UpdateCourseRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
