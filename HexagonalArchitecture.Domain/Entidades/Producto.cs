namespace HexagonalArchitecture.Domain.Entidades;

public class Producto
{
    public Guid productoId { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public decimal Costo { get; set; }
    public decimal Precio { get; set; }
    public int CantidadEnStock { get; set; }
    public List<VentaDetalle> VentaDetalles { get; set; }

}