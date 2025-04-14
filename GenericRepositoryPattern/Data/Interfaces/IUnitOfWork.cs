using GenericRepositoryPattern.Models;

namespace GenericRepositoryPattern.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveAsync();
    }
}
