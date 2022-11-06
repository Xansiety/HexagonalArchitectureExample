namespace HexagonalArchitecture.Domain.Interfaces;
public interface IAgregar<TEntidad>
{
    TEntidad Agregar(TEntidad entidad);
}
