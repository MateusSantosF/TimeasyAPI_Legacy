using TimeasyAPI.Controllers.Middlewares.Exceptions;
using TimeasyAPI.src.DTOs.Room;
using TimeasyAPI.src.DTOs.Teacher.Requests;
using TimeasyAPI.src.DTOs.Timetable;
using TimeasyAPI.src.DTOs.Timetable.Requests;
using TimeasyAPI.src.Helpers;
using TimeasyAPI.src.Mappings;
using TimeasyAPI.src.Models.UI;
using TimeasyAPI.src.Models.ValueObjects.Enums;
using TimeasyAPI.src.Repositories.Interfaces;
using TimeasyAPI.src.Services.Interfaces;
using TimeasyAPI.src.UnitOfWork;

namespace TimeasyAPI.src.Services
{
    public class TimetableServices : ITimetableServices
    {


        private readonly IUnitOfWork _unitOfWork;
        private readonly ITimetableRepository _timetableRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly Serilog.ILogger _logger;

        public TimetableServices(ITimetableRepository timetableRepository, 
            ISubjectRepository subjectRepository,
            IRoomRepository roomRepository,
            ICourseRepository courseRepository,
            IUnitOfWork unitOfWork, Serilog.ILogger logger)
        {
            _timetableRepository = timetableRepository;
            _roomRepository = roomRepository;
            _courseRepository = courseRepository;
            _subjectRepository = subjectRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<TimetableDTO> CreateAsync(CreateTimetableRequest request, Guid instituteId)
        {

            var newTimetable = request.MapToEntitie();
            newTimetable.InstituteId = instituteId;
            newTimetable.Status = TimetableStatus.ANALYSE;
            newTimetable.CreateAt = GetCurrentDate();



        

            try
            {
                _timetableRepository.Attach(newTimetable);
                _roomRepository.Attach(newTimetable.Rooms);
                _unitOfWork.CreateTransaction();
                var result = await _timetableRepository.CreateAsync(newTimetable);
                _unitOfWork.Commit();
                await _unitOfWork.SaveChangesAsync();

                return result.EntitieToMap();
            }catch(Exception ex){
                _unitOfWork.Rollback();
                _logger.Error($"Um erro ocorreu durante a criação do quadro de horario {ex.Message}");
                throw new DatabaseException("Um erro ocorreu durante a criação do quadro de horários");
            }

        }

        private DateOnly GetCurrentDate()
        {
            var offset = TimeSpan.FromHours(-3);
            var currentDateWithOffset = DateTimeOffset.UtcNow.ToOffset(offset);
            var dateOnlyWithOffset = new DateOnly(currentDateWithOffset.Year, currentDateWithOffset.Month, currentDateWithOffset.Day);

            return dateOnlyWithOffset;
        }

        public async Task<PagedResult<TimetableDTO>> GetAllAsync(int page, int pageSize)
        {
            var result = await _timetableRepository.GetAllAsync(page, pageSize);

            var timetableDTOS = result.Results.Select(timetable =>
            {
                return timetable.EntitieToMap();
            }).ToList();

            var pagedResultDTO = new PagedResult<TimetableDTO>
            {
                CurrentPage = result.CurrentPage,
                PageSize = result.PageSize,
                RowCount = result.RowCount,
                Results = timetableDTOS
            };

            return pagedResultDTO;
        }

        public Task RemoveByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UpdateTeacherRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
