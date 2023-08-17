using Microsoft.EntityFrameworkCore;
using TimeasyAPI.src.Data;
using TimeasyAPI.src.Models;
using TimeasyAPI.src.Repositories.Interfaces;

namespace TimeasyAPI.src.Repositories
{
    public class InstituteRepository : GenericRepository<Institute>, IInstituteRepository
    {
        private DbSet<Institute> _entitie;
        private readonly Serilog.ILogger _logger;

        public InstituteRepository(Serilog.ILogger logger, TimeasyDbContext context) : base(logger, context)
        {

            _logger = logger;
            DbContext = context;
            _entitie = context.Set<Institute>();

        }
        public async Task<Institute?> GetByIdWithIntervalsAsync(Guid id)
        {
            return await _entitie.Select(a => new Institute
            {
                Id = id,
                Name = a.Name,
                OpenHour = a.OpenHour,
                CloseHour = a.CloseHour,
                Monday = a.Monday,
                Tuesday = a.Tuesday,
                Wednesday = a.Wednesday,
                Thursday = a.Thursday,
                Friday = a.Friday,
                Saturday = a.Saturday,
                Intervals = a.Intervals.Where( i => i.Active == true ).ToList()
            }).FirstOrDefaultAsync();
        }
    }
}
