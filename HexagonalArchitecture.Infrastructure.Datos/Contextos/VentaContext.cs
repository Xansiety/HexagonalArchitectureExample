using HexagonalArchitecture.Domain.Entidades;
using HexagonalArchitecture.Infrastructure.Datos.Configs;
using Microsoft.EntityFrameworkCore;

namespace HexagonalArchitecture.Infrastructure.Datos.Contextos;

public class VentaContext : DbContext
{
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Venta> Ventas { get; set; } 
    public DbSet<VentaDetalle> VentaDetalles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(@"Server=.;Database=HexagonalArquitectureDB;Integrated Security=true;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ProductoConfig());
        builder.ApplyConfiguration(new VentasConfig());
        builder.ApplyConfiguration(new VentaDetalleConfig());
    }

}
