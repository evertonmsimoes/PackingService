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
            var boxes = new Boxes[] 
            {
                new Boxes { Id = 1, Nome = "Caixa 1", Altura = 30, Largura = 40, Comprimento = 80 },
                new Boxes { Id = 2, Nome = "Caixa 2", Altura = 80, Largura = 50, Comprimento = 40 },
                new Boxes { Id = 3, Nome = "Caixa 3", Altura = 50, Largura = 80, Comprimento = 60 }
            };

            modelBuilder.Entity<Boxes>().HasData(boxes);
        }
    }
}
