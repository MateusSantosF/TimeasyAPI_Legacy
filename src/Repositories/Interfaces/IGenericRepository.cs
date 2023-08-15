using TimeasyAPI.src.Models;
using TimeasyAPI.src.Models.UI;

namespace TimeasyAPI.src.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public Task<PagedResult<T>> GetAll(int page, int  pageSize);

        public Task<T> Create(T entity);

        public Task Update(T entity);

        public Task Delete(T entity);   

        public Task<T> GetById(Guid id);
        
    }
}
