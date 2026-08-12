using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Data;

public class ErpDbContext : DbContext
{
    public ErpDbContext(DbContextOptions<ErpDbContext> options)
        : base(options)
    {
    }

    public DbSet<Usuario> Usuarios => Set<Usuario>();

    public DbSet<Rol> Roles => Set<Rol>();

    public DbSet<Permiso> Permisos => Set<Permiso>();

    public DbSet<Modulo> Modulos => Set<Modulo>();

    public DbSet<Pedido> Pedidos => Set<Pedido>();
}