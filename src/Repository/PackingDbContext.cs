using Microsoft.EntityFrameworkCore;
using PackingService.Entities;

namespace PackingService.Repository
{
    public class PackingDbContext : DbContext
    {
        public DbSet<Boxes> Boxes { get; set; }

        public PackingDbContext(DbContextOptions<PackingDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
