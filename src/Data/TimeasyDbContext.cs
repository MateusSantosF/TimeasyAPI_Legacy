using Microsoft.EntityFrameworkCore;

namespace TimeasyAPI.src.Data
{
    public class TimeasyDbContext : DbContext
    {

        public TimeasyDbContext(DbContextOptions<TimeasyDbContext> options): base (options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TimeasyDbContext).Assembly);
        }
    }
}
