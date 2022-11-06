namespace HexagonalArchitecture.Domain.Interfaces;

public interface IListar<TEntidad, TEntidadID>
{
    List<TEntidad> Listar();
    TEntidad SeleccionarPorId(TEntidadID entidadID);
}
