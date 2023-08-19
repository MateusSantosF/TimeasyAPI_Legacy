using TimeasyAPI.Controllers.Middlewares.Exceptions;
using TimeasyAPI.src.DTOs.Room;
using TimeasyAPI.src.DTOs.Room.Request;
using TimeasyAPI.src.Mappings;
using TimeasyAPI.src.Models.UI;
using TimeasyAPI.src.Repositories.Interfaces;
using TimeasyAPI.src.Services.Interfaces;
using TimeasyAPI.src.UnitOfWork;
using TimeasyAPI.src.Helpers;

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
                throw new DatabaseException($"Erro ao criar sala {ex.Message}");
            }
            return room.EntitieToMap();
        }

        public async Task<PagedResult<RoomDTO>> GetAllAsync(int page, int pageSize)
        {
            var result =  await _roomRepository.GetAllWithTypeAsync(page, pageSize);

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
                throw new AppException("Nenhuma sala encontrada com o Id informado.");
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
                throw new DatabaseException("Um erro ocorreu durante a atualização.");
            }
            

        }

        public async Task UpdateAsync(UpdateRoomRequest request)
        {
            var roomId = request.Id.TryGetIdByString();

            var result = await _roomRepository.GetByIdAsync(roomId);

            if (result is null)
            {
                throw new AppException("Nenhuma sala encontrada com o Id informado.");
            }
                
            if(request.TypeId != null)
            {
                result.RoomTypeId = Guid.Parse(request.TypeId);
            }

            if( request.Capacity != null )
            {
                result.Capacity = (int)request.Capacity;
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
                throw new DatabaseException("Um erro ocorreu durante a atualização.");
            }

        }


    }
}
