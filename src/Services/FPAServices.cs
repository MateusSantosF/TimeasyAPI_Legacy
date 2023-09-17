using System.Linq.Expressions;
using TimeasyAPI.Controllers.Middlewares.Exceptions;
using TimeasyAPI.src.DTOs.FPA.requests;
using TimeasyAPI.src.DTOs.FPA.Schedule;
using TimeasyAPI.src.Helpers;
using TimeasyAPI.src.Mappings;
using TimeasyAPI.src.Models;
using TimeasyAPI.src.Models.Core;
using TimeasyAPI.src.Models.ValueObjects;
using TimeasyAPI.src.Models.ValueObjects.Enums;
using TimeasyAPI.src.Repositories.Interfaces;
using TimeasyAPI.src.Services.Interfaces;
using TimeasyAPI.src.UnitOfWork;

namespace TimeasyAPI.src.Services
{
    public class FPAServices : IFPAServices
    {

        private IUnitOfWork _unitOfWork;
        private IFPARepository _fpaRepository;
        private ISubjectService _subjectService;
        private Serilog.ILogger _logger;
        public FPAServices(IFPARepository fpaRepository, ISubjectService subjectService ,IUnitOfWork unitOfWork, Serilog.ILogger logger)
        {
            _fpaRepository = fpaRepository;
            _unitOfWork = unitOfWork;
            _subjectService = subjectService;
            _logger = logger;
        }

        public async Task FillAsync(FillFPARequest request)
        {

            Expression<Func<FPA, bool>> query = fpa =>
            fpa.TimetableId.Equals(request.TimetableId)
            && fpa.Teacher.Email.Equals(request.Email)
            && fpa.Teacher.BirthDate.Equals(request.BirthDate.TryParseToBrLocateDate())
            && fpa.Teacher.Registration.Equals(request.Registration);
            
            var searchFpa = await _fpaRepository.FindAsync(query);

            if( searchFpa is null)
            {
                throw new AppException(ErrorMessages.FpaNotFound);
            }

            try
            {
                if (!await _subjectService.CheckIfExistsAsync(request.Subjects.Select(s => s.SubjectId).ToList()))
                {
                    throw new AppException(ErrorMessages.SubjectNotFound);
                }

                searchFpa.Status = FPAStatus.COMPLETED;
                searchFpa.Schedules.AddRange(MappingSchedules(request.Schedules));
                searchFpa.Subjects.AddRange(MappingSubjects(request.Subjects));

                _unitOfWork.CreateTransaction();
                _fpaRepository.Update(searchFpa);
                _unitOfWork.Commit();
                await _unitOfWork.SaveChangesAsync();
            }
            catch (FormatException)
            {
                throw new AppException(ErrorMessages.InvalidIdFormat);
            }
            catch (AppException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error while fill FPA: {ex.Message}");
                _unitOfWork.Rollback();
                throw new DatabaseException(ErrorMessages.AddIntervalsError);
            }
       
        }

        public List<Schedule> MappingSchedules(List<ScheduleDTO> schedules)
        {
            return schedules.Select(schedule =>
            {
                return schedule.MapToEntitie();
            }).ToList();
        }

        public List<FpaSubjects> MappingSubjects(List<FpaSubjectDTO> courseSubjects)
        {
            return courseSubjects.Select(cs =>
            {
                return new FpaSubjects
                {
                    CourseId = cs.CourseId,
                    SubjectId = cs.SubjectId,
                };
            }).ToList();
        }

    }
}
