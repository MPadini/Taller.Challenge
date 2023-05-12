using code.challenge.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace code.challenge.Repository.Configuration
{
    public class MemoryDbContext : DbContext
    {
        public MemoryDbContext(DbContextOptions<MemoryDbContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
    }
}
