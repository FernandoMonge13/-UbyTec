using Microsoft.AspNetCore.Mvc;
using UbyTECAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UbyTECAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private Cliente cliente = new();
        /// <summary>
        /// Get para cliente, retorna todos los clientes
        /// </summary>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> Get()
        {
            try
            {
                var entityList = cliente.get();
                return Ok(entityList);
            }
            catch (Exception)
            {
                return BadRequest("No se logró conectar a la base de datos");
            }
        }
        /// <summary>
        /// Get por id para cliente
        /// </summary>
        /// <param name="id">id del cliente a buscar</param>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Cliente>>> Get(int id)
        {
            try
            {
                var entityList = cliente.get(id.ToString());
                return Ok(entityList);
            }
            catch (Exception)
            {
                return BadRequest("No se logró conectar a la base de datos");
            }
        }
        /// <summary>
        /// Agrega un nuevo cliente 
        /// </summary>
        /// <param name="entity">Cliente a agregar</param>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // POST api/<ClienteController>
        [HttpPost]
        public async Task<ActionResult<List<Cliente>>> Post(Cliente entity)
        {
            List<Cliente> entityList = new();
            entityList.Add(entity);

            var result = entity.post(entity);

            return result ? Ok(entityList) : BadRequest($"No se ha logrado agregar a {entity.nombre}");
        }
        /// <summary>
        /// Modifica un cliente
        /// </summary>
        /// <param name="entity">Cliente actualizado</param>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // PUT api/<ClienteController>/5
        [HttpPut]
        public async Task<ActionResult<List<Cliente>>> Put(Cliente entity)
        {
            List<Cliente> entityList = new();
            entityList.Add(entity);

            var result = entity.put(entity);

            return result ? Ok(entityList) : BadRequest($"No se ha logrado actualizar a {entity.idCliente}");
        }
        /// <summary>
        /// Elimina un cliente
        /// </summary>
        /// <param name="id">id del cliente a eliminar</param>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Cliente>>> Delete(int id)
        {
            List<ProductosPedido> entityList = new();

            var result = cliente.delete(id.ToString());

            return result ? Ok(entityList) : BadRequest($"No se ha logrado eliminar a {id}");
        }
    }
}

