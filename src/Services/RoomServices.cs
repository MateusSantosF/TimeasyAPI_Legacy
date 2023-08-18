using TimeasyAPI.Controllers.Middlewares.Exceptions;
using TimeasyAPI.src.DTOs.Room;
using TimeasyAPI.src.DTOs.Room.Request;
using TimeasyAPI.src.Mappings;
using TimeasyAPI.src.Models.UI;
using TimeasyAPI.src.Repositories.Interfaces;
using TimeasyAPI.src.Services.Interfaces;
using TimeasyAPI.src.UnitOfWork;

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

        public async Task RemoveByIdAsync(string id)
        {

            var isValidId = Guid.TryParse(id, out Guid roomid);

            if (!isValidId)
            {
                throw new AppException("Id inválido");
            }

            var result = await _roomRepository.GetByIdAsync(roomid);

            if(result is null)
            {
                throw new AppException("Nenhuma sala encontrada com o Id informado.");
            }

            try
            {
                result.Active = false;
                _roomRepository.Update(result);

                await _unitOfWork.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new DatabaseException(ex.Message);
            }
            

        }
    }
}
