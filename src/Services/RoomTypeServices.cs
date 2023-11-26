using System.Linq.Expressions;
using TimeasyAPI.Controllers.Middlewares.Exceptions;
using TimeasyAPI.src.DTOs.RoomType;
using TimeasyAPI.src.Helpers;
using TimeasyAPI.src.Mappings;
using TimeasyAPI.src.Models;
using TimeasyAPI.src.Models.UI;
using TimeasyAPI.src.Models.ValueObjects.Enums;
using TimeasyAPI.src.Repositories.Interfaces;
using TimeasyAPI.src.Services.Interfaces;
using TimeasyAPI.src.UnitOfWork;

namespace TimeasyAPI.src.Services
{
    public class RoomTypeServices : IRoomTypeServices
    {

        private IUnitOfWork _unitOfWork;
        private IGenericRepository<RoomType> _roomTypeRepository;
        private Serilog.ILogger _logger;
        public RoomTypeServices(IGenericRepository<RoomType> roomTypeRepository, IUnitOfWork unitOfWork, Serilog.ILogger logger)

        {
            _roomTypeRepository = roomTypeRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<RoomTypeDTO> CreateAsync(CreateRoomTypeRequest request)
        {
            if(request.IsComputerLab && request.OperationalSystem == null)
            {
                throw new AppException(ErrorMessages.ComputerLabMissingOS);
            }

            var newRoomType = request.MapToEntitie();

            try
            {
              
                _unitOfWork.CreateTransaction();
                await _roomTypeRepository.CreateAsync(newRoomType);
                _unitOfWork.Commit();
                await _unitOfWork.SaveChangesAsync();
            }
            catch (AppException)
            {
                throw;
            }
            catch( Exception ex)
            {
                _logger.Error($"Erro ao criar RoomType {ex.Message}. ${ex.StackTrace}");
                _unitOfWork.Rollback();
                throw new AppException(ErrorMessages.CreateRoomTypeError);

            }

            return newRoomType.EntitieToMap();
        }

        public async Task DeleteAsync(Guid id)
        {
            var result = await _roomTypeRepository.GetByIdAsync(id);
            
            if(result is null)
            {
                throw new AppException(ErrorMessages.RoomTypeNotFound);
            }

            if(!result.Active)
            {
                return;
            }

            result.Active = false;

            try
            {
                _unitOfWork.CreateTransaction();
                _roomTypeRepository.Update(result);
                _unitOfWork.Commit();
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                _logger.Error($"Erro ao deletar RoomType");
                _unitOfWork.Rollback();
                throw new AppException(ErrorMessages.DeleteRoomTypeError);
            }
        
        }

        public async Task<PagedResult<RoomTypeDTO>> GetAllAsync(int page, int pageSize, string? name)
        {

            PagedResult<RoomType> result; 

            if(name is not null)
            {
                Expression<Func<RoomType, bool>> searchCondition = entity => entity.Name.Contains(name);
                result = await _roomTypeRepository.GetAllAsync(page, pageSize, searchCondition);
            }
            else
            {
                result = await _roomTypeRepository.GetAllAsync(page, pageSize);
            }

            var roomTypeDTOs = result.Results.Select(room =>
            {
                return room.EntitieToMap();
            }).ToList();

            var pagedResultDTO = new PagedResult<RoomTypeDTO>
            {
                CurrentPage = result.CurrentPage,
                PageSize = result.PageSize,
                RowCount = result.RowCount,
                Results = roomTypeDTOs
            };

            return pagedResultDTO;
        }

        public async Task<List<RoomTypeDTO>> GetAllAsync()
        {
            var result =  await _roomTypeRepository.GetAllAsync();

            return result.Select(roomtype =>
            {
                return roomtype.EntitieToMap();
            }).ToList();
        }

        public async Task UpdateAsync(UpdateRoomTypeRequest request)
        {


            var result = await _roomTypeRepository.GetByIdAsync(request.Id);

            if(result == null)
            {
                throw new AppException(ErrorMessages.RoomTypeNotFound);
            }

            if (!string.IsNullOrEmpty(request.Name))
            {
                result.Name = request.Name;
            }

 
            if (request.IsComputerLab.HasValue)
            {
                var isLab = request.IsComputerLab.Value;
                
                if(isLab && !request.OperationalSystem.HasValue)
                {
                    throw new AppException(ErrorMessages.ComputerLabMissingOS);
                }

                if (request.OperationalSystem.HasValue && isLab)
                {
                    result.IsComputerLab = true;
                    result.OperationalSystem = request.OperationalSystem.Value;
                }
                else
                {
                    result.IsComputerLab = false;
                    result.OperationalSystem = null;
                }
            }
            else
            {
                result.IsComputerLab = false;
                result.OperationalSystem = null;
            }

            try
            {
                _unitOfWork.CreateTransaction();
                _roomTypeRepository.Update(result);
                _unitOfWork.Commit();
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                _logger.Error($"Erro ao atualizar RoomType");
                _unitOfWork.Rollback();
                throw new AppException(ErrorMessages.UpdateRoomTypeError);
            }

        }
    }
}
