using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TimeasyAPI.src.Data;
using TimeasyAPI.src.Helpers;
using TimeasyAPI.src.Models;
using TimeasyAPI.src.Models.UI;
using TimeasyAPI.src.Repositories.Interfaces;

namespace TimeasyAPI.src.Repositories
{
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {

        private DbSet<Room> _entitie;
        private readonly Serilog.ILogger _logger;

        public RoomRepository(Serilog.ILogger logger, TimeasyDbContext context): base(logger, context)
        {

            _logger = logger;
            DbContext = context;
            _entitie = context.Set<Room>();
            
        }
        public async Task<PagedResult<Room>> GetAllWithTypeAsync(int page, int pageSize)
        {
            return await _entitie.Include(room => room.Type)
                                 .AsNoTracking()
                                 .Where(r => r.Active == true)
                                 .GetPagedAsync(page, pageSize);
        }

        public async Task<PagedResult<Room>> GetAllWithTypeAsync(int page, int pageSize, Expression<Func<Room,bool>> search)
        {
            return await _entitie.Include(room => room.Type)
                                 .AsNoTracking()
                                 .Where(r => r.Active == true)
                                 .Where(search)
                                 .GetPagedAsync(page, pageSize);
        }

        public async Task<List<Room>> GetAllRoomsById(List<Guid> roomsId)
        {
            return await _entitie.AsNoTracking().Where(s => roomsId.Contains(s.Id)).ToListAsync();
        }
    }
}
