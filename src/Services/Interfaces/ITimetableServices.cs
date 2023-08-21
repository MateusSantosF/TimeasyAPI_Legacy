using TimeasyAPI.Controllers.Middlewares.Exceptions;
using TimeasyAPI.src.DTOs.Courses;
using TimeasyAPI.src.DTOs.Room;
using TimeasyAPI.src.DTOs.Subject;
using TimeasyAPI.src.DTOs.Teacher.Requests;
using TimeasyAPI.src.DTOs.Timetable;
using TimeasyAPI.src.DTOs.Timetable.Requests;
using TimeasyAPI.src.Helpers;
using TimeasyAPI.src.Models.UI;

namespace TimeasyAPI.src.Services.Interfaces
{
    public interface ITimetableServices
    {
        Task<PagedResult<TimetableDTO>> GetAllAsync(int page, int pageSize);
        Task RemoveByIdAsync(Guid id);
        Task<TimetableDTO> CreateAsync(CreateTimetableRequest request, Guid instituteId);
        Task UpdateAsync(UpdateTeacherRequest request);
        Task RemoveSubjectFromTimetable(Guid timetableId, Guid subjectId);
        Task RemoveCourseFromTimetable(Guid timetableId, Guid courseId);
        Task<List<RoomDTO>> GetTimetableRooms(Guid timetableId);
        Task<List<SubjectDTO>> GetTimetableSubjects(Guid timetableId);
        Task<List<CourseDTO>> GetTimetableCourses(Guid timetableId);
    }
}
