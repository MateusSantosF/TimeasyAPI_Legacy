using Microsoft.EntityFrameworkCore;
using TimeasyAPI.src.Data;
using TimeasyAPI.src.Models.Core;
using TimeasyAPI.src.Repositories.Interfaces;

namespace TimeasyAPI.src.Repositories
{
    public class ScheduleRepository : GenericRepository<Schedule>,IScheduleRepository
    {
        private DbSet<Schedule> _entitie;
        private readonly Serilog.ILogger _logger;

        public ScheduleRepository(Serilog.ILogger logger, TimeasyDbContext context) : base(logger, context)
        {

            _logger = logger;
            DbContext = context;
            _entitie = context.Set<Schedule>();

        }

        public async Task AddRange(List<Schedule> intervals)
        {
            await _entitie.AddRangeAsync(intervals);
        }
    }
}
