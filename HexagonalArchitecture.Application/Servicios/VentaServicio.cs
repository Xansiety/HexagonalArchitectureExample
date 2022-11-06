

using HexagonalArchitecture.Application.Interfaces;
using HexagonalArchitecture.Domain.Entidades;
using HexagonalArchitecture.Domain.Interfaces.Repositorios;

namespace HexagonalArchitecture.Application.Servicios;

public class VentaServicio : IServicioMovimiento<Venta, Guid>
{
    IRepositorioMovimiento<Venta, Guid> repositorioVenta;
    IRepositorioBase<Producto, Guid> repositorioProducto;
    IRepositorioDetalleVenta<VentaDetalle, Guid> repositorioVentaDetalle;

    public VentaServicio(IRepositorioMovimiento<Venta, Guid> _repoVenta, IRepositorioBase<Producto, Guid> _repoBase, IRepositorioDetalleVenta<VentaDetalle, Guid> _repoVentaDetalle)
    {
        repositorioVenta = _repoVenta;
        repositorioProducto = _repoBase;
        repositorioVentaDetalle = _repoVentaDetalle;
    }

    public Venta Agregar(Venta entidad)
    {
        if (entidad is null) throw new ArgumentNullException("La venta es requerida");

        var ventaAgregada = repositorioVenta.Agregar(entidad);

        entidad.VentaDetalles.ForEach(detalle =>
        {
            var productoSeleccionado = repositorioProducto.SeleccionarPorId(detalle.ProductoId);
            if (productoSeleccionado is null) throw new NullReferenceException("Usted esta intentado vender un producto que no existe");

            //var detalleNuevo = new VentaDetalle();
            detalle.VentaId = ventaAgregada.VentaId;
            detalle.ProductoId = detalle.ProductoId;
            detalle.CostoUnitario = productoSeleccionado.Costo;
            detalle.PrecioUnitario = productoSeleccionado.Precio;
            detalle.CantidadVendida = detalle.CantidadVendida;
            detalle.Subtotal = detalle.PrecioUnitario * detalle.CantidadVendida;
            detalle.Impuesto = detalle.Subtotal * 16 / 100;
            detalle.Total = detalle.Subtotal + detalle.Impuesto;
            repositorioVentaDetalle.Agregar(detalle);
            //Actualizamos el stock
            productoSeleccionado.CantidadEnStock -= detalle.CantidadVendida;
            repositorioProducto.Editar(productoSeleccionado);

            // Colocamos totales de venta
            entidad.Subtotal += detalle.Subtotal;
            entidad.Impuesto += detalle.Impuesto;
            entidad.Total += detalle.Total;

        });

        repositorioVenta.GuardarTodosLosCambios();
        return entidad;
    }

    public void Anular(Guid entidadID)
    {
        repositorioVenta.Anular(entidadID);
        repositorioVenta.GuardarTodosLosCambios();
    }

    public List<Venta> Listar()
    {
        return repositorioVenta.Listar();
    }

    public Venta SeleccionarPorId(Guid entidadID)
    {
        return repositorioVenta.SeleccionarPorId(entidadID);
    }
}
