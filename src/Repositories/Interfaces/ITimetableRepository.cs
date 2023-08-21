using TimeasyAPI.src.Models;
using TimeasyAPI.src.Models.ValueObjects;

namespace TimeasyAPI.src.Repositories.Interfaces
{
    public interface ITimetableRepository : IGenericRepository<Timetable>
    {
        Task<TimetableSubjects> GetTimetableSubjectByIdAsync(Guid timetableId, Guid subjectId);

        Task<TimetableCourses> GetTimetableCourseByIdAsync(Guid timetableId, Guid courseId);

        void RemoveSubjectFromTimetable(TimetableSubjects timetableSubject);

        void RemoveCourseFromTimetable(TimetableCourses timetableCourse);

        Task<Timetable> GetTimetableCoursesAsync(Guid timetableId);

        Task<Timetable> GetTimetableSubjectsAsync(Guid timetableId);

        Task<Timetable> GetTimetableRoomsAsync(Guid timetableId);

        Task<Timetable> GetTimetableCoursesWithSubjectsAsync(Guid timetableId);
    }
}
