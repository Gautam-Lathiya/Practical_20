using GenericRepositoryPattern.Models;

namespace GenericRepositoryPattern.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        Task<int> SaveAsync();
    }
}
