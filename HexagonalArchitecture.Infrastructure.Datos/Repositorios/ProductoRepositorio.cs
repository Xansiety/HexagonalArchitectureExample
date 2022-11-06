using HexagonalArchitecture.Domain.Entidades;
using HexagonalArchitecture.Domain.Interfaces.Repositorios;
using HexagonalArchitecture.Infrastructure.Datos.Contextos;

namespace HexagonalArchitecture.Infrastructure.Datos.Repositorios;

public class ProductoRepositorio : IRepositorioBase<Producto, Guid>
{
    private VentaContext db;
    public ProductoRepositorio(VentaContext _db)
    {
        db = _db;
    }

    public Producto Agregar(Producto entidad)
    {
        entidad.productoId = Guid.NewGuid();
        db.Productos.Add(entidad);
        return entidad;
    }

    public void Editar(Producto entidad)
    {
        var productoSeleccionado = db.Productos.Where(p => p.productoId == entidad.productoId).FirstOrDefault();

        if (productoSeleccionado is not null)
        {
            productoSeleccionado.Nombre = entidad.Nombre;
            productoSeleccionado.Descripcion = entidad.Descripcion;
            productoSeleccionado.Costo = entidad.Costo;
            productoSeleccionado.Precio = entidad.Precio;
            productoSeleccionado.CantidadEnStock = entidad.CantidadEnStock;

            db.Entry(productoSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

    }

    public void Eliminar(Guid entidadID)
    {
        var productoSeleccionado = db.Productos.Where(p => p.productoId == entidadID).FirstOrDefault();
        if (productoSeleccionado is not null)
        { 
            db.Productos.Remove(productoSeleccionado);
        }
    }

    public void GuardarTodosLosCambios()
    {
        db.SaveChanges();
    }

    public List<Producto> Listar()
    {
        return db.Productos.ToList();
    }

    public Producto SeleccionarPorId(Guid entidadID)
    {
        var productoSeleccionado = db.Productos.Where(p => p.productoId == entidadID).FirstOrDefault();  
        return productoSeleccionado;
    }
}
