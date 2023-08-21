using TimeasyAPI.Controllers.Middlewares.Exceptions;
using TimeasyAPI.src.DTOs.Course.Requests;
using TimeasyAPI.src.DTOs.Courses;
using TimeasyAPI.src.Helpers;
using TimeasyAPI.src.Mappings;
using TimeasyAPI.src.Models.UI;
using TimeasyAPI.src.Models.ValueObjects;
using TimeasyAPI.src.Repositories.Interfaces;
using TimeasyAPI.src.Services.Interfaces;
using TimeasyAPI.src.UnitOfWork;

namespace TimeasyAPI.src.Services
{
    public class CourseServices : ICourseServices
    {

        private readonly ICourseRepository _courseRepository;

        private ISubjectRepository _subjectRepository;
        private IUnitOfWork _unitOfWork;
        private Serilog.ILogger _logger;
        public CourseServices(ICourseRepository courseRepository, ISubjectRepository subjectRepository, IUnitOfWork unitOfWork, Serilog.ILogger logger)

        {
            _courseRepository = courseRepository;
            _subjectRepository = subjectRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<CourseDTO> CreateAsync(CreateCourseRequest request, Guid instituteId)
        {
            var course = request.MapToEntitie();
            course.InstituteId = instituteId;

            var validPeriodAmount = course.CourseSubject.All(s => s.Period <= course.PeriodAmount);

            if (!validPeriodAmount)
            {
                throw new AppException(ErrorMessages.InvalidSubjectPeriod);
            }

            try
            {
                _unitOfWork.CreateTransaction();
                course = await _courseRepository.CreateAsync(course);
                _unitOfWork.Commit();
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.Error($"Erro ao criar Course ${ex.Message}");
                _unitOfWork.Rollback();
                throw new DatabaseException(ErrorMessages.CreateCourseError);
            }
            return course.EntitieToMap();
        }

        public async Task<PagedResult<CourseDTO>> GetAllAsync(int page, int pageSize)
        {
            var result =  await _courseRepository.GetAllWithSubjectsAsync(page, pageSize);

            var courseDTOs = result.Results.Select(room =>
            {
                return room.EntitieToMap();
            }).ToList();

            var pagedResultDTO = new PagedResult<CourseDTO>
            {
                CurrentPage = result.CurrentPage,
                PageSize = result.PageSize,
                RowCount = result.RowCount,
                Results = courseDTOs
            };

            return pagedResultDTO;
        }


        public async Task RemoveByIdAsync(Guid id)
        {
            var result = await _courseRepository.GetByIdAsync(id);

            if (result is null)
            {
                throw new AppException(ErrorMessages.CourseNotFound);
            }

            if (!result.Active)
            {
                return;
            }

            try
            {
                result.Active = false;
                _courseRepository.Update(result);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new DatabaseException(ErrorMessages.DeleteCourseError);
            }

        }

        public async Task RemoveCourseSubjectByIdAsync(DeleteCourseSubjectsRequest request)
        {

            var course = await _courseRepository.GetByIdWithSubjectsAsync(request.CourseId);

            if(course == null)
            {
                throw new  AppException(ErrorMessages.CourseNotFound);
            }

            var subjects = await _subjectRepository.GetAllById(request.Subjects);

            if (subjects == null)
            {
                throw new AppException(ErrorMessages.NoSubjectsFound);
            }

            var allSubjectsBelongsCourse = subjects.All(s => course.CourseSubject.Any(cs => s.Id.Equals(cs.SubjectId)));

            if (!allSubjectsBelongsCourse)
            {
                throw new AppException(ErrorMessages.SubjectNotBelongsCourse);
            }

            if (course.CourseSubject.Count.Equals(subjects.Count))
            {
                throw new AppException(ErrorMessages.CourseMinSubjects);
            }

            var subjectsForRemove = subjects.Select(sb =>
            {
                return new CourseSubject
                {
                    SubjectId = sb.Id,
                    CourseId = course.Id
                };
            }).ToList();

            try
            {
                _courseRepository.RemoveCurseSubject(subjectsForRemove);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new DatabaseException(ErrorMessages.RemoveCourseError);
            }

        }

        public async Task UpdateAsync(UpdateCourseRequest request)
        {

            var result = await _courseRepository.GetByIdWithSubjectsAsync(request.CourseId);

            if(result == null)
            {
                throw new AppException(ErrorMessages.CourseNotFound);
            }

            if(request.Name != null)
            {
                result.Name = request.Name;
            }

            if (request.Turn.HasValue)
            {
                result.Turn = request.Turn.Value;
            }

            if (request.Period.HasValue)
            {
                result.Period = request.Period.Value;
            }

            if(request.PeriodAmount.HasValue){

                result.PeriodAmount = request.PeriodAmount.Value;
            }

            if (request.Subjects != null && request.Subjects.Any())
            {

                // Remove current subjects
                _courseRepository.RemoveCurseSubject(result.CourseSubject);
                result.CourseSubject.Clear();


                var subjectsIds = request.Subjects.Select(s => s.SubjectId).ToList();
                var subjects = await _subjectRepository.GetAllById(subjectsIds);
       
                var updatedCourseSubjects = subjects.Select(sb =>
                {
                    return new CourseSubject
                    {
                        SubjectId = sb.Id,
                        CourseId = result.Id
                    };
                }).ToList();

                result.CourseSubject.AddRange(updatedCourseSubjects);
            }
   
            try
            {
                _unitOfWork.CreateTransaction();
                _courseRepository.Update(result);
                _unitOfWork.Commit();
                await _unitOfWork.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw new DatabaseException(ErrorMessages.UpdateCourseError);
            }
        }
    }
}
