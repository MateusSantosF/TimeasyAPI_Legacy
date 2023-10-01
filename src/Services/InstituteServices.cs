using TimeasyAPI.Controllers.Middlewares.Exceptions;
using TimeasyAPI.src.DTOs.Institute;
using TimeasyAPI.src.DTOs.Institute.Request;
using TimeasyAPI.src.Helpers;
using TimeasyAPI.src.Mappings;
using TimeasyAPI.src.Repositories.Interfaces;
using TimeasyAPI.src.Services.Interfaces;
using TimeasyAPI.src.UnitOfWork;

namespace TimeasyAPI.src.Services
{
    public class InstituteServices : IInstituteServices
    {

        private IUnitOfWork _unitOfWork;
        private IInstituteRepository _instituteRepository;
        private IIntervalRepository _intervalRepository;
        private Serilog.ILogger _logger;
        public InstituteServices(IInstituteRepository instituteRepository, IIntervalRepository intervalRepository, IUnitOfWork unitOfWork, Serilog.ILogger logger)

        {
            _intervalRepository = intervalRepository;
            _instituteRepository = instituteRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task AddIntervals(AddIntervalsRequest request)
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
                _logger.Error($"Error while adding intervals: {ex.Message}");
                _unitOfWork.Rollback();
                throw new DatabaseException(ErrorMessages.AddIntervalsError);
            }
        }

        public async Task<InstituteDTO> GetById(Guid instituteId)
        {
            try
            {

                var institute = await _instituteRepository.GetByIdWithIntervalsAsync(instituteId);

                if (institute == null)
                {
                    throw new AppException(ErrorMessages.InstituteNotFound);
                }

                return institute.EntitieToMap();
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
                _logger.Error($"Error while retrieving institute: {ex.Message}");
                _unitOfWork.Rollback();
                throw new DatabaseException($"Error while retrieving institute: {ex.Message}");
            }
        }

        public async Task UpdateAsync(UpdateInstituteRequest request)
        {
            // TODO: verificar se a instituição que está sendo atualizada é do usuário que fez a request

            try
            {
                var updatedInstitute = request.MapToEntitie();
                _unitOfWork.CreateTransaction();
                _instituteRepository.Update(updatedInstitute);
                _unitOfWork.Commit();
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.Error($"Error while updating institute: {ex.Message}");
                _unitOfWork.Rollback();
                throw new DatabaseException(ErrorMessages.UpdateInstituteError);
            }
        }
    }
}
