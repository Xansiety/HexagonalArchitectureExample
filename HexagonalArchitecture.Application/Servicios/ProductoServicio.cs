using HexagonalArchitecture.Application.Interfaces;
using HexagonalArchitecture.Domain.Entidades;
using HexagonalArchitecture.Domain.Interfaces.Repositorios;

namespace HexagonalArchitecture.Application.Servicios;

public class ProductoServicio : IServicioBase<Producto, Guid>
{

    private readonly IRepositorioBase<Producto, Guid> repositorioProducto;


    public ProductoServicio(IRepositorioBase<Producto, Guid> _repoProducto)
    {
        repositorioProducto = _repoProducto;
    }

    public Producto Agregar(Producto entidad)
    {
        if (entidad is null) throw new ArgumentNullException("El producto es requerido");
        var resultproducto = repositorioProducto.Agregar(entidad);
        repositorioProducto.GuardarTodosLosCambios();
        return resultproducto;
    }

    public void Editar(Producto entidad)
    {
        if (entidad is null) throw new ArgumentNullException("El producto es requerido para editar");
        repositorioProducto.Editar(entidad);
        repositorioProducto.GuardarTodosLosCambios();
    }

    public void Eliminar(Guid entidadID)
    {
        repositorioProducto.Eliminar(entidadID);
        repositorioProducto.GuardarTodosLosCambios();
    }

    public List<Producto> Listar()
    {
      return repositorioProducto.Listar();
    }

    public Producto SeleccionarPorId(Guid entidadID)
    {
       return repositorioProducto.SeleccionarPorId(entidadID);
    }
}
