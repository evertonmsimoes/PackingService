using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PackingService.Repository;

public class PackingDbContextFactory : IDesignTimeDbContextFactory<PackingDbContext>
{
    public PackingDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PackingDbContext>();

        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=PackingServiceDb;User Id=sa;Password=I8S*4N482b80NgsWAprh4<4//;TrustServerCertificate=True;");

        return new PackingDbContext(optionsBuilder.Options);
    }
}
