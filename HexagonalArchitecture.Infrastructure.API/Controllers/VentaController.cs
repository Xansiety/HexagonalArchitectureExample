using HexagonalArchitecture.Application.Servicios;
using HexagonalArchitecture.Domain.Entidades;
using HexagonalArchitecture.Infrastructure.Datos.Contextos;
using HexagonalArchitecture.Infrastructure.Datos.Repositorios;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HexagonalArchitecture.Infrastructure.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {

        VentaServicio CrearServicio()
        {
            VentaContext db = new VentaContext();
            VentaRepositorio ventaRepositorio = new VentaRepositorio(db);
            ProductoRepositorio productoRepositorio = new ProductoRepositorio(db);
            VentaDetalleRepositorio ventaDetalleRepositorio = new VentaDetalleRepositorio(db);
            VentaServicio servicio = new VentaServicio(ventaRepositorio, productoRepositorio, ventaDetalleRepositorio);
            return servicio;
        }

        // GET: api/<VentaController>
        [HttpGet]
        public ActionResult<List<Venta>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        // GET api/<VentaController>/5
        [HttpGet("{id}")]
        public ActionResult<Venta> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.SeleccionarPorId(id));
        }

        // POST api/<VentaController>
        [HttpPost]
        public ActionResult Post([FromBody] Venta venta)
        {
            var servicio = CrearServicio();
            servicio.Agregar(venta);
            return Ok($"La venta se genero exitosamente");
        }
         

        // DELETE api/<VentaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var servicio = CrearServicio();
            servicio.Anular(id);
            return Ok($"La venta se anulo exitosamente");
        }
    }
}
