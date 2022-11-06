using HexagonalArchitecture.Domain.Interfaces;

namespace HexagonalArchitecture.Application.Interfaces;

public interface IServicioMovimiento<TEntidad, TEntidadID> : IAgregar<TEntidad>, IListar<TEntidad, TEntidadID>
{
    void Anular(TEntidadID entidadID);
}
