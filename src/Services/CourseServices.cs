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
        private IUnitOfWork _unitOfWork;
        private Serilog.ILogger _logger;
        public CourseServices(ICourseRepository courseRepository, IUnitOfWork unitOfWork, Serilog.ILogger logger)

        {
            _courseRepository = courseRepository;
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

        public Task UpdateAsync(UpdateCourseRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
