using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ERP.Infrastructure.Data;

public class ErpDbContextFactory : IDesignTimeDbContextFactory<ErpDbContext>
{
    public ErpDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ErpDbContext>();

        var connectionString =
            Environment.GetEnvironmentVariable("ERP_CONNECTION_STRING")
            ?? "Host=localhost;Port=5432;Database=erp_db;Username=postgres;Password=TU_PASSWORD";

        optionsBuilder.UseNpgsql(connectionString);

        return new ErpDbContext(optionsBuilder.Options);
    }
}
