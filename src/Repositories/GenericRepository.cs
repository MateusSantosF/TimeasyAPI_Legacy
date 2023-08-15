using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TimeasyAPI.Controllers.Middlewares.Exceptions;
using TimeasyAPI.src.Data;
using TimeasyAPI.src.Helpers;
using TimeasyAPI.src.Models;
using TimeasyAPI.src.Models.UI;
using TimeasyAPI.src.Repositories.Interfaces;

namespace TimeasyAPI.src.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private DbSet<T> _entitie;
        private readonly Serilog.ILogger _logger;

        public GenericRepository(Serilog.ILogger logger, TimeasyDbContext context) { 
            
            _logger = logger;
            DbContext = context;
            _entitie = context.Set<T>();
        }

        public TimeasyDbContext DbContext { get; set; }
        
     
        public async Task<T> CreateAsync(T entity)
        {
            try
            {
                await _entitie.AddAsync(entity);
                return entity;
            }
            catch (OperationCanceledException dbEx)
            {
                _logger.Error(dbEx.Message);
                throw new AppException("Erro ao criar entidade");
            }
        }

        public Task DeleteAsync(T entity)
        {
            _entitie.Remove(entity); 
            return Task.CompletedTask;
        }

        public async Task<PagedResult<T>> GetAllAsync(int page, int pageSize)
        {
            return await _entitie.GetPagedAsync(page, pageSize);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _entitie.Where(entitie => entitie.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _entitie.Where(predicate).FirstOrDefaultAsync();
        }

        public Task UpdateAsync(T entity)
        {
            DbContext.Update(entity);
            return Task.CompletedTask;
        }

    }
}
