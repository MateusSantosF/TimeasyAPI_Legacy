using System.Linq.Expressions;
using TimeasyAPI.src.Models;
using TimeasyAPI.src.Models.UI;
using TimeasyAPI.src.Models.ValueObjects;

namespace TimeasyAPI.src.Repositories.Interfaces
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<PagedResult<Course>> GetAllWithSubjectsAsync(int page, int pageSize);

        Task<PagedResult<Course>> GetAllWithSubjectsAsync(int page, int pageSize, Expression<Func<Course, bool>> search);

        Task<Course?> GetByIdWithSubjectsAsync(Guid courseId);

        Task<List<Course>> GetAllCoursesById(List<Guid> coursesIds);

        void RemoveCurseSubject(List<CourseSubject> courseSubject);
    }
}
