namespace HexagonalArchitecture.Domain.Entidades;

public class Venta
{
    public Guid VentaId { get; set; }
    public long NumeroVenta { get; set; }
    public DateTime Fecha { get; set; }
    public string Concepto { get; set; }
    public decimal Subtotal { get; set; }
    public decimal Impuesto { get; set; }
    public decimal Total { get; set; }
    public Boolean Anulado { get; set; } = false;
    public List<VentaDetalle> VentaDetalles { get; set; }
}