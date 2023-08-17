using TimeasyAPI.Controllers.Middlewares.Exceptions;
using TimeasyAPI.src.DTOs.Institute;
using TimeasyAPI.src.DTOs.Institute.Request;
using TimeasyAPI.src.Mappings;
using TimeasyAPI.src.Models;
using TimeasyAPI.src.Repositories.Interfaces;
using TimeasyAPI.src.Services.Interfaces;
using TimeasyAPI.src.UnitOfWork;

namespace TimeasyAPI.src.Services
{
    public class InstituteServices : IInstituteServices
    {

        private IUnitOfWork _unitOfWork;
        private IGenericRepository<Institute> _instituteRepository;
        private Serilog.ILogger _logger;
        public InstituteServices(IGenericRepository<Institute> instituteRepository, IUnitOfWork unitOfWork, Serilog.ILogger logger)

        {
            _instituteRepository = instituteRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }


        public async Task UpdateAsync(UpdateInstituteRequest request)
        {

            // TODO verificar se a instituição que está sendo atualizada é mesmo do usuario que fez a request

            try
            {
                var updatedInstitute = request.MapToEntitie();
                _unitOfWork.CreateTransaction();
                await _instituteRepository.UpdateAsync(updatedInstitute);
                _unitOfWork.Commit();
                _unitOfWork.SaveChanges();
            }
            catch(Exception ex)
            {          
                _logger.Error($"Erro ao criar Sala ${ex.Message}");
                _unitOfWork.Rollback();
                throw new DatabaseException($"Erro ao atualizar instituto {ex.Message}");
            }
        }
    }
}
