﻿using TimeasyAPI.Controllers.Middlewares.Exceptions;
using TimeasyAPI.src.DTOs.RoomType;
using TimeasyAPI.src.Mappings;
using TimeasyAPI.src.Models;
using TimeasyAPI.src.Models.UI;
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
                throw new AppException("O sistema operacional do laboratório é obrigatorio.");
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
                throw new AppException("Erro ao criar tipo sala.");

            }

            return newRoomType.EntitieToMap();
        }

        public async Task DeleteAsync(Guid id)
        {
            var result = await _roomTypeRepository.GetByIdAsync(id);
            
            if(result is null)
            {
                throw new AppException("Tipo de sala não encontrado.");
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
                throw new AppException("Erro ao criar tipo sala.");
            }
        
        }

        public async Task<PagedResult<RoomTypeDTO>> GetAllAsync(int page, int pageSize)
        {
            var result = await _roomTypeRepository.GetAllAsync(page, pageSize);

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
    }
}
