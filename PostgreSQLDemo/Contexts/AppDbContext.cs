using Microsoft.EntityFrameworkCore;
using PostgreSQLDemo.Models;

namespace PostgreSQLDemo.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> employees { get; set; }
    }
}
