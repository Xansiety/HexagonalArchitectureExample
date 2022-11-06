namespace HexagonalArchitecture.Domain.Interfaces.Repositorios;

public interface IRepositorioDetalleVenta<TEntidad, TMovimientoID> : IAgregar<TEntidad>, ITransaccion
{

}