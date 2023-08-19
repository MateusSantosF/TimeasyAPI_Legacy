using Microsoft.EntityFrameworkCore;
using TimeasyAPI.src.Data;
using TimeasyAPI.src.DTOs.Subject;
using TimeasyAPI.src.Helpers;
using TimeasyAPI.src.Models;
using TimeasyAPI.src.Models.UI;
using TimeasyAPI.src.Repositories.Interfaces;

namespace TimeasyAPI.src.Repositories
{
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {

        private DbSet<Subject> _entitie;
        private readonly Serilog.ILogger _logger;

        public SubjectRepository(Serilog.ILogger logger, TimeasyDbContext context) : base(logger, context)
        {
            _logger = logger;
            DbContext = context;
            _entitie = context.Set<Subject>();
        }

        public async Task<PagedResult<Subject>> GetAllWithRoomTypeAsync(int page, int pageSize)
        {
            return await _entitie.Include(s => s.RoomTypeNeeded)
                                  .AsNoTracking()
                                  .Where(s => s.Active == true)
                                  .GetPagedAsync(page, pageSize);
        }

        public async Task<List<Subject>> GetAllById(List<Guid> subjectsId)
        {
            return await _entitie.AsNoTracking().Where(s => subjectsId.Contains(s.Id)).ToListAsync();
        }
    }
}
