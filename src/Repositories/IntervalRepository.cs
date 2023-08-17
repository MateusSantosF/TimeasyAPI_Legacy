using Microsoft.EntityFrameworkCore;
using TimeasyAPI.src.Data;
using TimeasyAPI.src.Models;
using TimeasyAPI.src.Repositories.Interfaces;

namespace TimeasyAPI.src.Repositories
{
    public class IntervalRepository : GenericRepository<Interval>,IIntervalRepository
    {
        private DbSet<Interval> _entitie;
        private readonly Serilog.ILogger _logger;

        public IntervalRepository(Serilog.ILogger logger, TimeasyDbContext context) : base(logger, context)
        {

            _logger = logger;
            DbContext = context;
            _entitie = context.Set<Interval>();

        }

        public async Task AddRange(List<Interval> intervals)
        {
            await _entitie.AddRangeAsync(intervals);
        }
    }
}
