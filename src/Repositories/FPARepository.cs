using Microsoft.EntityFrameworkCore;
using TimeasyAPI.src.Data;
using TimeasyAPI.src.Models;
using TimeasyAPI.src.Repositories.Interfaces;

namespace TimeasyAPI.src.Repositories
{
    public class FPARepository : GenericRepository<FPA>,IFPARepository
    {
        private DbSet<FPA> _entitie;
        private readonly Serilog.ILogger _logger;

        public FPARepository(Serilog.ILogger logger, TimeasyDbContext context) : base(logger, context)
        {
            _logger = logger;
            DbContext = context; 
            _entitie = context.Set<FPA>();
        }

        public async Task AddRange(List<FPA> fpas)
        {
            await _entitie.AddRangeAsync(fpas);
        }
    }
}
