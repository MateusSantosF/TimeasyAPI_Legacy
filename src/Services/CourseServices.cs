using TimeasyAPI.Controllers.Middlewares.Exceptions;
using TimeasyAPI.src.DTOs.Course.Requests;
using TimeasyAPI.src.DTOs.Courses;
using TimeasyAPI.src.DTOs.Room;
using TimeasyAPI.src.Mappings;
using TimeasyAPI.src.Models.UI;
using TimeasyAPI.src.Repositories;
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
                throw new DatabaseException($"Erro ao criar Curso");
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
                throw new AppException("Nenhum Curso encontrado com o Id informado.");
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
                throw new DatabaseException("Um erro ocorreu durante a remoção.");
            }

        }

        public async Task RemoveCourseSubjectByIdAsync(Guid courseId, Guid subjectId)
        {

            var course = await _courseRepository.GetByIdWithSubjectsAsync(courseId);

            if(course == null)
            {
                throw new  AppException("Não foi encontrado um curso com o Id informado");
            }

            var subject = await _subjectRepository.GetByIdAsync(subjectId);

            if (subject == null)
            {
                throw new AppException("Não foi encontrado nenhuma disciplina com o Id informado");
            }

            var subjectCourse = course.CourseSubject.Find(c => c.SubjectId.Equals(subjectId));

            if (subjectCourse == null)
            {
                throw new AppException("Disciplina informada não pertence ao curso.");
            }

            try
            {
                _courseRepository.RemoveCurseSubject(subjectCourse);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new DatabaseException("Um erro ocorreu durante a remoção.");
            }

        }

        public Task UpdateAsync(UpdateCourseRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
