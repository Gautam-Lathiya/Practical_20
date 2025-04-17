using GenericRepositoryPattern.Models;

namespace GenericRepositoryPattern.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Employee> EmployeeRepository { get; }
        IGenericRepository<Department> DepartmentRepository { get; }
        Task<int> SaveAsync();
    }
}
