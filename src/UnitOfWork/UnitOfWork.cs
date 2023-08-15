using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using TimeasyAPI.src.UnitOfWork;

namespace TimeasyAPI.src.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>, IDisposable where TContext : DbContext, new()
    {
        private bool _disposed;
        private IDbContextTransaction _objTran;

        public TContext Context { get; }

        public UnitOfWork()
        {
            Context = new TContext();
        }

        public void CreateTransaction()
        {
            _objTran = Context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _objTran.Commit();
        }

        public void Rollback()
        {
            _objTran.Rollback();
            _objTran.Dispose();
        }

        public void Save()
        {
            try
            {
                //Calling DbContext Class SaveChanges method 
                Context.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {

            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    Context.Dispose();
            _disposed = true;
        }
    }
}
