using HexagonalArchitecture.Infrastructure.Datos.Contextos;
 
public class Program
{
    static void Main(String[] args)
    {
        Console.WriteLine("Creando la Base de datos si no existe");
        VentaContext db = new VentaContext();
        db.Database.EnsureCreated();
        Console.WriteLine("Base de datos creada");
        Console.ReadKey();
    }
}
