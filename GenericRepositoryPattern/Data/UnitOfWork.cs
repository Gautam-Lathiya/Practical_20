using GenericRepositoryPattern.Data.Interfaces;
using GenericRepositoryPattern.Models;

namespace GenericRepositoryPattern.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Employee> EmployeeRepository => new GenericRepository<Employee>(_context);
        public IGenericRepository<Department> DepartmentRepository => new GenericRepository<Department>(_context);

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
