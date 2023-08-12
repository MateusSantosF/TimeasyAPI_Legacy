using TimeasyAPI.src.Models;

namespace TimeasyAPI.src.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {

        public Task<T> Create(T entity);

        public Task<T> Update(T entity);

        public void Delete(T entity);   

        public Task<T> GetById(Guid id);
        
    }
}
