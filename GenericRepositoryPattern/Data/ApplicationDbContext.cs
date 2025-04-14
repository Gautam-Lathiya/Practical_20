using GenericRepositoryPattern.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GenericRepositoryPattern.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
