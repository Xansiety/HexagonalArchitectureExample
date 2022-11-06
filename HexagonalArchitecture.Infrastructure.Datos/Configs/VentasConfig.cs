using HexagonalArchitecture.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HexagonalArchitecture.Infrastructure.Datos.Configs;

public class VentasConfig : IEntityTypeConfiguration<Venta>
{
    public void Configure(EntityTypeBuilder<Venta> builder)
    {
        builder.ToTable("Ventas");
        builder.HasKey(v => v.VentaId); //Primary Key
         
        builder.HasMany(venta => venta.VentaDetalles)
            .WithOne(detalle => detalle.Venta);
    }
}
