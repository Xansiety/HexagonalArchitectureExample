using HexagonalArchitecture.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HexagonalArchitecture.Infrastructure.Datos.Configs;

public class VentaDetalleConfig : IEntityTypeConfiguration<VentaDetalle>
{
    public void Configure(EntityTypeBuilder<VentaDetalle> builder)
    {
        builder.ToTable("VentasDetalles");
        builder.HasKey(vd =>  new { vd.ProductoId, vd.VentaId}); //Primary Key compuesta
        
        builder.HasOne(detalle => detalle.Producto)
            .WithMany(producto => producto.VentaDetalles);

        builder.HasOne(detalle => detalle.Venta)
            .WithMany(producto => producto.VentaDetalles);
    }
}
