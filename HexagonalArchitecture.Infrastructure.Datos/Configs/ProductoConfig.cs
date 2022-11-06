using HexagonalArchitecture.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HexagonalArchitecture.Infrastructure.Datos.Configs;

public class ProductoConfig : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.ToTable("Productos");
        builder.HasKey(p => p.productoId); //Primary Key

        //relación un producto tenga muchos venta detalle y que venta detalle tendrá un producto
        builder.HasMany(producto => producto.VentaDetalles)
            .WithOne(detalle => detalle.Producto);

    }
}
