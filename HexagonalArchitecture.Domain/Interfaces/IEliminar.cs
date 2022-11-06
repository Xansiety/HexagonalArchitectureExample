

namespace HexagonalArchitecture.Domain.Interfaces;

public interface IEliminar<TEntidadID>
{
    void Eliminar(TEntidadID entidadID);
}
