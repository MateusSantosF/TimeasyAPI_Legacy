namespace TimeasyAPI.src.UnitOfWork
{
    public interface IUnitOfWork 
    {
        void CreateTransaction();
        void Commit();
        void Rollback();
        Task SaveChangesAsync();
    }
}
