using TimeasyAPI.Controllers.Middlewares.Exceptions;
using TimeasyAPI.src.DTOs.Institute.Request;
using TimeasyAPI.src.Helpers;
using TimeasyAPI.src.Mappings;
using TimeasyAPI.src.Repositories.Interfaces;
using TimeasyAPI.src.Services.Interfaces;
using TimeasyAPI.src.UnitOfWork;

namespace TimeasyAPI.src.Services
{
    public class IntervalServices : IIntervalServices
    {

        private IUnitOfWork _unitOfWork;
        private IInstituteRepository _instituteRepository;
        private IIntervalRepository _intervalRepository;
        private Serilog.ILogger _logger;
        public IntervalServices(IInstituteRepository instituteRepository, IIntervalRepository intervalRepository, IUnitOfWork unitOfWork, Serilog.ILogger logger)

        {
            _intervalRepository = intervalRepository;
            _instituteRepository = instituteRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task AddIntervalsAsync(AddIntervalsRequest request)
        {
            try
            {
                var instituteId = request.InstituteId;
                var institute = await _instituteRepository.GetByIdAsync(instituteId);

                if (institute == null)
                {
                    throw new AppException(ErrorMessages.InstituteNotFound);
                }

                var intervals = request.Intervals.Select(i =>
                {
                    var interval = i.MapToEntitie();
                    interval.InstituteId = instituteId;
                    return interval;
                }).ToList();


                _unitOfWork.CreateTransaction();
                await _intervalRepository.AddRange(intervals);
                _unitOfWork.Commit();
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.Error($"Erro ao adicionar intervalos ${ex.Message}");
                _unitOfWork.Rollback();
                throw new DatabaseException(ErrorMessages.AddIntervalsError);
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                var intervalId = id.TryGetIdByString();
                var interval = await _intervalRepository.GetByIdAsync(intervalId);

                if (interval == null)
                {
                    throw new AppException(ErrorMessages.IntervalNotFound);
                }

                if (!interval.Active)
                {
                    return;
                }

                interval.Active = false;

                _unitOfWork.CreateTransaction();
                 _intervalRepository.Update(interval);
                _unitOfWork.Commit();
                await _unitOfWork.SaveChangesAsync();
            }
            catch (AppException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.Error($"Erro ao deletar intervalo. ${ex.Message}");
                _unitOfWork.Rollback();
                throw new DatabaseException(ErrorMessages.DeleteIntervalError);
            }
        }
    }
}
