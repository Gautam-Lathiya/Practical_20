using Microsoft.EntityFrameworkCore;
using Practical_20.Logging;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;

namespace Practical_20.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AuditLog> AuditLogs { get; set; }
    }
}
