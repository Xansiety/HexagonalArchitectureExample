using HexagonalArchitecture.Domain.Entidades;
using HexagonalArchitecture.Domain.Interfaces.Repositorios;
using HexagonalArchitecture.Infrastructure.Datos.Contextos;

namespace HexagonalArchitecture.Infrastructure.Datos.Repositorios;

public class VentaRepositorio : IRepositorioMovimiento<Venta, Guid>
{
    private VentaContext db;
    public VentaRepositorio(VentaContext _db)
    {
        db = _db;
    }

    public Venta Agregar(Venta entidad)
    {
        entidad.VentaId = Guid.NewGuid();
        db.Ventas.Add(entidad);
        return entidad;
    }

    public void Anular(Guid entidadId)
    {
        var ventaSeleccionada = db.Ventas.Where(v => v.VentaId == entidadId).FirstOrDefault();
        if (ventaSeleccionada is null) throw new NullReferenceException("Esta intentado anular una venta que no existe");

        ventaSeleccionada.Anulado = true;
        db.Entry(ventaSeleccionada).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

    }

    public void GuardarTodosLosCambios()
    {
        db.SaveChanges();
    }

    public List<Venta> Listar()
    {
        return db.Ventas.ToList();
    }

    public Venta SeleccionarPorId(Guid entidadID)
    {
        var ventaSeleccionada = db.Ventas.Where(v => v.VentaId == entidadID).FirstOrDefault();
        return ventaSeleccionada;
    }
}
