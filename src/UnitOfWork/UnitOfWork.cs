using Microsoft.EntityFrameworkCore.Storage;
using TimeasyAPI.src.Data;

namespace TimeasyAPI.src.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TimeasyDbContext _dbContext;
        private  IDbContextTransaction? _transactionObj;

        public UnitOfWork(TimeasyDbContext context) {
            _dbContext = context;
        }
      
        public void CreateTransaction()
        {
            _transactionObj = _dbContext.Database.BeginTransaction();
        }
        public void Commit()
        {
            _transactionObj?.Commit();
        }

        public async Task SaveChangesAsync()
        {
             await _dbContext.SaveChangesAsync();
        }

        public void Rollback()
        {
            try
            {
                _transactionObj?.RollbackAsync();

            }
            catch (Exception)
            {

            }
        }
    }
}
