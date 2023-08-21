using Microsoft.EntityFrameworkCore;
using TimeasyAPI.src.Data;
using TimeasyAPI.src.Models;
using TimeasyAPI.src.Models.ValueObjects;
using TimeasyAPI.src.Repositories.Interfaces;

namespace TimeasyAPI.src.Repositories
{
    public class TimetableRepository: GenericRepository<Timetable>, ITimetableRepository
    {
        private DbSet<Timetable> _entitie;
        private DbSet<TimetableSubjects> _timetableSubject;
        private DbSet<TimetableCourses> _timetableCourses;
        private readonly Serilog.ILogger _logger;

        public TimetableRepository(Serilog.ILogger logger, TimeasyDbContext context) : base(logger, context)
        {
            _logger = logger;
            DbContext = context;
            _timetableCourses = context.Set<TimetableCourses>();
            _timetableSubject = context.Set<TimetableSubjects>();
            _entitie = context.Set<Timetable>();
        }

        public async Task<TimetableSubjects> GetTimetableSubjectByIdAsync(Guid timetableId, Guid subjectId)
        {
           return await _timetableSubject.AsNoTracking()
                    .Where(t => t.TimetableId.Equals(timetableId) && t.SubjectId.Equals(subjectId))
                    .FirstOrDefaultAsync();
        }


        public async Task<TimetableCourses> GetTimetableCourseByIdAsync(Guid timetableId, Guid courseId)
        {
            return  await _timetableCourses.AsNoTracking()
                     .Where(t => t.TimetableId.Equals(timetableId) && t.CourseId.Equals(courseId))
                     .FirstOrDefaultAsync();
        }

        public async Task<Timetable> GetTimetableCoursesAsync(Guid timetableId)
        {
            return await _entitie
                        .Where(t => t.Id.Equals(timetableId))
                        .Include(t => t.TimetableCourses)
                        .AsNoTracking()
                        .FirstOrDefaultAsync();
        }

        public async Task<Timetable> GetTimetableSubjectsAsync(Guid timetableId)
        {
            return await _entitie
                        .Where(t => t.Id.Equals(timetableId))
                        .Include(t => t.TimetableSubjects)
                        .AsNoTracking()
                        .FirstOrDefaultAsync();
        }

        public async Task<Timetable> GetTimetableRoomsAsync(Guid timetableId)
        {
            return await _entitie
                        .Where(t => t.Id.Equals(timetableId))
                        .Include(t => t.Rooms)
                        .AsNoTracking()
                        .FirstOrDefaultAsync();
        }

        public void RemoveSubjectFromTimetable(TimetableSubjects timetableSubject)
        {
            _timetableSubject.Remove(timetableSubject);
        }

        public void RemoveCourseFromTimetable(TimetableCourses timetableCourse)
        {
            _timetableCourses.Remove(timetableCourse);
        }


    }
}
