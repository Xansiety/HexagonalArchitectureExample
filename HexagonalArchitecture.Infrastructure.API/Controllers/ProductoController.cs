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
    public class ProductoController : ControllerBase
    {

        ProductoServicio CrearServicio()
        {
            VentaContext db = new VentaContext();
            ProductoRepositorio productoRepositorio = new ProductoRepositorio(db);
            ProductoServicio servicio = new ProductoServicio(productoRepositorio);
            return servicio;
        }


        // GET: api/<ProductoController>
        [HttpGet]
        public ActionResult<List<Producto>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public ActionResult<Producto> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.SeleccionarPorId(id));
        }

        // POST api/<ProductoController>
        [HttpPost]
        public ActionResult Post([FromBody] Producto producto)
        {
            var servicio = CrearServicio();
            servicio.Agregar(producto);
            return Ok($"El producto ${producto.Nombre} se agrego de manera satisfactoria a tu catalogo");
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Producto producto)
        {
            var servicio = CrearServicio();
            producto.productoId = id;
            servicio.Editar(producto);
            return Ok($"El producto ${producto.Nombre} se modifico de manera satisfactoria");
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var servicio = CrearServicio();
            servicio.Eliminar(id);
            return Ok($"El producto se removió de manera satisfactoria de tu catalogo");
        }
    }
}
