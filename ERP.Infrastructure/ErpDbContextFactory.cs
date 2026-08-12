using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ERP.Infrastructure.Data;

public class ErpDbContextFactory : IDesignTimeDbContextFactory<ErpDbContext>
{
    public ErpDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ErpDbContext>();

        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5432;Database=erp_db;Username=postgres;Password=123456"
        );

        return new ErpDbContext(optionsBuilder.Options);
    }
}