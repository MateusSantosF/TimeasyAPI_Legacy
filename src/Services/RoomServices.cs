﻿using TimeasyAPI.Controllers.Middlewares.Exceptions;
using TimeasyAPI.src.DTOs.Room;
using TimeasyAPI.src.DTOs.Room.Request;
using TimeasyAPI.src.Mappings;
using TimeasyAPI.src.Models.UI;
using TimeasyAPI.src.Repositories.Interfaces;
using TimeasyAPI.src.Services.Interfaces;
using TimeasyAPI.src.UnitOfWork;
using TimeasyAPI.src.Helpers;
using TimeasyAPI.src.Models;
using System.Linq.Expressions;

namespace TimeasyAPI.src.Services
{
    public class RoomServices : IRoomServices
    {

        private IUnitOfWork _unitOfWork;
        private IRoomRepository _roomRepository;
        private Serilog.ILogger _logger;
        public RoomServices(IRoomRepository roomRepository, IUnitOfWork unitOfWork, Serilog.ILogger logger)

        {
            _roomRepository = roomRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<RoomDTO> CreateAsync(CreateRoomRequest request)
        {

            var room = request.MapToEntitie();
      
            try
            {
                _unitOfWork.CreateTransaction();
                room = await _roomRepository.CreateAsync(room);
                _unitOfWork.Commit();
                await _unitOfWork.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                _logger.Error($"Erro ao criar Sala ${ex.Message}");
                _unitOfWork.Rollback();
                throw new DatabaseException(ErrorMessages.CreateRoomError);
            }
            return room.EntitieToMap();
        }

        public async Task<PagedResult<RoomDTO>> GetAllAsync(int page, int pageSize, string? name)
        {

            PagedResult<Room> result;

            if(name is null)
            {
                result = await _roomRepository.GetAllWithTypeAsync(page, pageSize);
            }
            else
            {
                Expression<Func<Room, bool>> search = room => room.Name.Contains(name);

                result = await _roomRepository.GetAllWithTypeAsync(page, pageSize, search);
            }
            

            var roomDTOs = result.Results.Select(room =>
            {
                return room.EntitieToMap();
            }).ToList();

            var pagedResultDTO = new PagedResult<RoomDTO>
            {
                CurrentPage = result.CurrentPage,
                PageSize = result.PageSize,
                RowCount = result.RowCount,
                Results = roomDTOs 
            };

            return pagedResultDTO;
        }

        public async Task RemoveByIdAsync(Guid id)
        {

            var result = await _roomRepository.GetByIdAsync(id);

            if(result is null)
            {
                throw new AppException(ErrorMessages.RoomNotFound);
            }

            if (!result.Active)
            {
                return;
            }

            try
            {
                result.Active = false;
                _roomRepository.Update(result);

                await _unitOfWork.SaveChangesAsync();
            }
            catch(Exception)
            {
                throw new DatabaseException(ErrorMessages.RemoveRoomError);
            }
        }

        public async Task UpdateAsync(UpdateRoomRequest request)
        {
            var roomId = request.Id;

            var result = await _roomRepository.GetByIdAsync(roomId);

            if (result is null)
            {
                throw new AppException(ErrorMessages.RoomNotFound);
            }
                
            if(request.RoomTypeId.HasValue)
            {
                result.RoomTypeId = request.RoomTypeId.Value;
            }

            if( request.Capacity.HasValue)
            {
                result.Capacity = request.Capacity.Value;
            }

            if(!string.IsNullOrEmpty(request.Name))
            {
                result.Name = request.Name;
            }

            if( !string.IsNullOrEmpty(request.Block))
            {
                result.Block = request.Block;
            }

            try
            {
                _unitOfWork.CreateTransaction();
                _roomRepository.Update(result);
                _unitOfWork.Commit();
                await _unitOfWork.SaveChangesAsync();

            }catch(Exception )
            {
                throw new DatabaseException(ErrorMessages.UpdateRoomError);
            }

        }


    }
}
