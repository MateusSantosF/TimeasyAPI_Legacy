using Microsoft.EntityFrameworkCore;
using TimeasyAPI.src.Data;
using TimeasyAPI.src.Models;
using TimeasyAPI.src.Repositories.Interfaces;

namespace TimeasyAPI.src.Repositories
{
    public class TimetableRepository: GenericRepository<Timetable>, ITimetableRepository
    {
        private DbSet<Timetable> _entitie;

        private readonly Serilog.ILogger _logger;

        public TimetableRepository(Serilog.ILogger logger, TimeasyDbContext context) : base(logger, context)
        {
            _logger = logger;
            DbContext = context;
            _entitie = context.Set<Timetable>();
        }

   

     
    }
}
