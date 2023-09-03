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
                throw new DatabaseException("Erro ao criar entidade");
            }
        }

        public void Attach(T entity)
        {
            _entitie.Attach(entity);
        }

        public void Attach(IEnumerable<T> entities)
        {
            _entitie.AttachRange(entities);
        }

        public void Delete(T entity)
        {
            _entitie.Remove(entity); 
        }

        public async Task<PagedResult<T>> GetAllAsync(int page, int pageSize, Expression<Func<T, bool>>? searchCondition = null)
        {
            IQueryable<T> query = _entitie.Where(e => e.Active == true);

            if (searchCondition != null)
            {
                query = query.Where(searchCondition);
            }

            return await query.GetPagedAsync(page, pageSize);
        }

        public async Task<PagedResult<T>> GetAllAsync(int page, int pageSize)
        {
            IQueryable<T> query = _entitie.Where(e => e.Active == true);

            return await query.GetPagedAsync(page, pageSize);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _entitie.AsNoTracking().Where(entitie => entitie.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _entitie.AsNoTracking().Where(predicate).FirstOrDefaultAsync();
        }

        public void Update(T entity)
        {
            DbContext.Update(entity);
        }

    }
}
