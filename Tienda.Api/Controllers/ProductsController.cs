using Microsoft.AspNetCore.Mvc;
using Tienda.Application.Interfaces;
using Tienda.Domain.Entities;

namespace Tienda.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        // GET: api/productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> Get()
        {
            var productos = await _productoService.ListarProductosAsync();
            return Ok(productos);
        }

        // GET: api/productos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> Get(int id)
        {
            var producto = await _productoService.ObtenerProductoPorIdAsync(id);
            if (producto == null)
                return NotFound();
            return Ok(producto);
        }

        // POST: api/productos
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Producto producto)
        {
            await _productoService.CrearProductoAsync(producto);
            return CreatedAtAction(nameof(Get), new { id = producto.Id }, producto);
        }

        // PUT: api/productos/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Producto producto)
        {
            if (id != producto.Id)
                return BadRequest("El ID de la URL no coincide con el del cuerpo.");

            try
            {
                await _productoService.ActualizarProductoAsync(producto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE: api/productos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _productoService.EliminarProductoAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
