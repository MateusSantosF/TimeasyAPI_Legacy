using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
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

        public async Task<PagedResult<Course>> GetAllWithSubjectsAsync(int page, int pageSize, Expression<Func<Course, bool>> search)
        {
            return await _entitie
                    .Include(c => c.CourseSubject)
                    .ThenInclude(cs => cs.Subject)
                    .AsNoTracking()
                    .Where(c => c.Active == true)
                    .Where(search)
                    .GetPagedAsync(page, pageSize);
        }


        public async Task<List<Course>> GetAllCoursesById(List<Guid> coursesIds)
        {
            return await _entitie.AsNoTracking().Where(s => coursesIds.Contains(s.Id)).ToListAsync();
        }

        public void RemoveCurseSubject(List<CourseSubject> courseSubjects)
        {
             _courseSubjects.RemoveRange(courseSubjects);
        }



        public async Task<Course?> GetByIdWithSubjectsAsync(Guid courseId)
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
