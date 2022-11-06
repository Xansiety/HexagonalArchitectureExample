using HexagonalArchitecture.Domain.Entidades;
using HexagonalArchitecture.Domain.Interfaces.Repositorios;
using HexagonalArchitecture.Infrastructure.Datos.Contextos;

namespace HexagonalArchitecture.Infrastructure.Datos.Repositorios;

public class VentaDetalleRepositorio : IRepositorioDetalleVenta<VentaDetalle, Guid>
{

    private VentaContext db;
    public VentaDetalleRepositorio(VentaContext _db)
    {
        db = _db;
    }


    public VentaDetalle Agregar(VentaDetalle entidad)
    {
        db.VentaDetalles.Add(entidad);
        return entidad;
    }

    public void GuardarTodosLosCambios()
    {
        db.SaveChanges();
    }
}
