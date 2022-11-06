namespace HexagonalArchitecture.Domain.Entidades;
public class VentaDetalle
{
    public Guid ProductoId { get; set; }
    public Guid VentaId { get; set; }
    public decimal CostoUnitario { get; set; }
    public decimal PrecioUnitario { get; set; }
    public int CantidadVendida { get; set; }
    public decimal Subtotal { get; set; }
    public decimal Impuesto { get; set; }
    public decimal Total { get; set; }
    public Producto Producto { get; set; }
    public Venta Venta { get; set; }
}