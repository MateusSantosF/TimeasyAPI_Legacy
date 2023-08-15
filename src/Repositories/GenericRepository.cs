using Microsoft.EntityFrameworkCore;
using TimeasyAPI.Controllers.Middlewares.Exceptions;
using TimeasyAPI.src.Data;
using TimeasyAPI.src.Helpers;
using TimeasyAPI.src.Models;
using TimeasyAPI.src.Models.UI;
using TimeasyAPI.src.Repositories.Interfaces;
using TimeasyAPI.src.UnitOfWork;

namespace TimeasyAPI.src.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>, IDisposable where T : BaseEntity
    {
        private DbSet<T> _entitie;
        private bool _isDisposed;
        private readonly Serilog.ILogger _logger;

        public GenericRepository(Serilog.ILogger logger, IUnitOfWork<TimeasyDbContext> unitOfWork): this(logger,unitOfWork.Context)
        {
            _logger = logger;
        }

        public GenericRepository(Serilog.ILogger logger, TimeasyDbContext context) { 
            
            _logger = logger;
            DbContext = context;
            _isDisposed = false;
        }

        public TimeasyDbContext DbContext { get; set; }
        protected virtual DbSet<T> Entitie
        {
            get { return _entitie ??= DbContext.Set<T>(); }
        }

        public async Task<T> Create(T entity)
        {
            try
            {
                await Entitie.AddAsync(entity);
                return entity;
            }
            catch (OperationCanceledException dbEx)
            {
                _logger.Error(dbEx.Message);
                throw new AppException("Erro ao criar entidade");
            }
        }

        public Task Delete(T entity)
        {
            Entitie.Remove(entity); 
            return Task.CompletedTask;
        }

        public async Task<PagedResult<T>> GetAll(int page, int pageSize)
        {
            return await Entitie.GetPagedAsync<T>(page, pageSize);
        }

        public async Task<T> GetById(Guid id)
        {
            return await Entitie.Where(entitie => entitie.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public Task Update(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            if (DbContext != null)
                DbContext.Dispose();
            _isDisposed = true;
        }
    }
}
