using System.Linq.Expressions;
using TimeasyAPI.src.Models;
using TimeasyAPI.src.Models.UI;
namespace TimeasyAPI.src.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public Task<PagedResult<T>> GetAllAsync(int page, int  pageSize, Expression<Func<T, bool>>? searchCondition);

        public Task<PagedResult<T>> GetAllAsync(int page, int pageSize);

        public Task<T> CreateAsync(T entity);

        public void Update(T entity);

        public void Delete(T entity);

        public void Attach(T entity);

        public void Attach(IEnumerable<T> entities);

        public Task<T> GetByIdAsync(Guid id);

        public Task<T> FindAsync(Expression<Func<T, bool>> predicate);


    }
}
