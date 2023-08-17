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
            return await _entitie.Include(room => room.Type).GetPagedAsync(page, pageSize);
        }
    }
}
