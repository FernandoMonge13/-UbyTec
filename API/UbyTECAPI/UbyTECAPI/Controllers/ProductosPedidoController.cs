using Microsoft.AspNetCore.Mvc;
using UbyTECAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UbyTECAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosPedidoController : ControllerBase
    {
        private ProductosPedido productosPedido = new();
        /// <summary>
        /// Get de productos por pedido
        /// </summary>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // GET: api/<ProductosPedidoController>
        [HttpGet]
        public async Task<ActionResult<List<ProductosPedido>>> Get()
        {
            try
            {
                var entityList = productosPedido.get();
                return Ok(entityList);
            }
            catch (Exception)
            {
                return BadRequest("No se logró conectar a la base de datos");
            }
        }
        /// <summary>
        /// Get pedidos por id
        /// </summary>
        /// <param name="id">id del pedido</param>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // GET api/<ProductosPedidoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ProductosPedido>>> Get(int id)
        {
            try
            {
                var entityList = productosPedido.get(id.ToString());
                return Ok(entityList);
            }
            catch (Exception)
            {
                return BadRequest("No se logró conectar a la base de datos");
            }
        }
        /// <summary>
        /// Agrega un producto pedido
        /// </summary>
        /// <param name="entity">entidad a agregar</param>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // POST api/<ProductosPedidoController>
        [HttpPost]
        public async Task<ActionResult<List<ProductosPedido>>> Post(ProductosPedido entity)
        {
            List<ProductosPedido> entityList = new();
            entityList.Add(entity);

            var result = entity.post(entity);

            return result ? Ok(entityList) : BadRequest($"No se ha logrado agregar a {entity.idPedido}");
        }

        /// <summary>
        /// Modifica un productos pedido
        /// </summary>
        /// <param name="entity">producto pedido modificado</param>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // PUT api/<ProductosPedidoController>/5
        [HttpPut]
        public async Task<ActionResult<List<ProductosPedido>>> Put(ProductosPedido entity)
        {
            List<ProductosPedido> entityList = new();
            entityList.Add(entity);

            var result = entity.put(entity);

            return result ? Ok(entityList) : BadRequest($"No se ha logrado actualizar a {entity.idPedido}");
        }

        /// <summary>
        /// Elimina un produtos pedidos
        /// </summary>
        /// <param name="id">id del pedido</param>
        /// <param name="producto">nombre del producto</param>
        /// <returns></returns>
        // DELETE api/<ProductosPedidoController>/5
        [HttpDelete("{id}/{producto}")]
        public async Task<ActionResult<List<ProductosPedido>>> Delete(int id,string producto)
        {
            List<ProductosPedido> entityList = new();

            var result = productosPedido.delete($"{id},'{producto}'");

            return result ? Ok(entityList) : BadRequest($"No se ha logrado eliminar a {id}");
        }
    }
}
