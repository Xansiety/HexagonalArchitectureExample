using HexagonalArchitecture.Domain.Interfaces;

namespace HexagonalArchitecture.Application.Interfaces;

public interface IServicioBase<TEntidad, TEntidadID> : IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad, TEntidadID>
{

}
