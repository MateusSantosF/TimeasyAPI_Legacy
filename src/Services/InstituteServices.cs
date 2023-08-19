using TimeasyAPI.Controllers.Middlewares.Exceptions;
using TimeasyAPI.src.DTOs.Institute;
using TimeasyAPI.src.DTOs.Institute.Request;
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

                if(institute == null)
                {
                    throw new AppException("Não foi encontrado nenhum instituto com o Id informado.");
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
            catch(FormatException)
            {
                throw new AppException("Id inválido");
            }
            catch (AppException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.Error($"Erro ao adicionar intervalos ${ex.Message}");
                _unitOfWork.Rollback();
                throw new DatabaseException($"Erro ao atualizar instituto. {ex.Message}");
            }

        }

        public async Task<InstituteDTO> GetById(string id)
        {
            try
            {
                var instituteId = Guid.Parse(id);
                var institute = await _instituteRepository.GetByIdWithIntervalsAsync(instituteId);

                if (institute == null)
                {
                    throw new AppException("Não foi encontrado nenhum instituto com o Id informado.");
                }

                return institute.EntitieToMap();
            }
            catch (FormatException)
            {
                throw new AppException("Id inválido");
            }
            catch (AppException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.Error($"Erro ao buscar instituto. ${ex.Message}");
                _unitOfWork.Rollback();
                throw new DatabaseException($"Erro ao buscar instituto. {ex.Message}");
            }
        }

        public async Task UpdateAsync(UpdateInstituteRequest request)
        {

            // TODO verificar se a instituição que está sendo atualizada é mesmo do usuario que fez a request

            try
            {
                var updatedInstitute = request.MapToEntitie();
                _unitOfWork.CreateTransaction();
                 _instituteRepository.Update(updatedInstitute);
                _unitOfWork.Commit();
                await _unitOfWork.SaveChangesAsync();
            }
            catch(Exception ex)
            {          
                _logger.Error($"Erro ao atualizar instituto ${ex.Message}");
                _unitOfWork.Rollback();
                throw new DatabaseException($"Erro ao atualizar instituto {ex.Message}");
            }
        }
    }
}
