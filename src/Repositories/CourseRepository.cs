using Microsoft.EntityFrameworkCore;
using TimeasyAPI.src.Data;
using TimeasyAPI.src.Helpers;
using TimeasyAPI.src.Models;
using TimeasyAPI.src.Models.UI;
using TimeasyAPI.src.Models.ValueObjects;
using TimeasyAPI.src.Repositories.Interfaces;

namespace TimeasyAPI.src.Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {

        private DbSet<Course> _entitie;
        private DbSet<CourseSubject> _courseSubjects;

        private readonly Serilog.ILogger _logger;

        public CourseRepository(Serilog.ILogger logger, TimeasyDbContext context) : base(logger, context)
        {

            _logger = logger;
            DbContext = context;
            _courseSubjects = context.Set<CourseSubject>();
            _entitie = context.Set<Course>();

        }

        public async Task<PagedResult<Course>> GetAllWithSubjectsAsync(int page, int pageSize)
        {
            return await _entitie
                    .Include(c => c.CourseSubject)
                    .ThenInclude( cs => cs.Subject)
                    .AsNoTracking()
                    .Where(c => c.Active == true)
                    .GetPagedAsync(page, pageSize);
        }

        public void RemoveCurseSubject(CourseSubject courseSubject)
        {
             _courseSubjects.Remove(courseSubject);
        }

        public async Task<Course> GetByIdWithSubjectsAsync(Guid courseId)
        {
            return await _entitie
                  .Include(c => c.CourseSubject)
                  .ThenInclude(cs => cs.Subject)
                  .AsNoTracking()
                  .Where(c => c.Active == true && c.Id == courseId)
                   .FirstOrDefaultAsync();
        }
    
    }
}
