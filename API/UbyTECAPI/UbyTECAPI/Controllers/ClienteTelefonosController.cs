using Microsoft.AspNetCore.Mvc;
using UbyTECAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UbyTECAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteTelefonosController : ControllerBase
    {
        private ClienteTelefonos clienteTelefonos = new();
        /// <summary>
        /// Get de telefionos de clientes
        /// </summary>
        /// <returns></returns>
        // GET: api/<ClienteTelefonosController>
        [HttpGet]
        public async Task<ActionResult<List<ClienteTelefonos>>> Get()
        {
            try
            {
                var entityList = clienteTelefonos.get();
                return Ok(entityList);
            }
            catch (Exception)
            {
                return BadRequest("No se logró conectar a la base de datos");
            }
        }
        /// <summary>
        /// Get de cliiente por id
        /// </summary>
        /// <param name="idCliente">id del cliente a buscar</param>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // GET api/<ClienteTelefonosController>/5
        [HttpGet("{idCliente}")]
        public async Task<ActionResult<List<ClienteTelefonos>>> Get(int idCliente)
        {
            try
            {
                var entityList = clienteTelefonos.get(idCliente.ToString());
                return Ok(entityList);
            }
            catch (Exception)
            {
                return BadRequest("No se logró conectar a la base de datos");
            }
        }
        /// <summary>
        /// Agregar un nuevo cliente telefono
        /// </summary>
        /// <param name="entity">Cliente telefono a agregar</param>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // POST api/<ClienteTelefonosController>
        [HttpPost]
        public async Task<ActionResult<List<ClienteTelefonos>>> Post(ClienteTelefonos entity)
        {
            List<ClienteTelefonos> entityList = new();
            entityList.Add(entity);

            var result = entity.post(entity);

            return result ? Ok(entityList) : BadRequest($"No se ha logrado agregar a {entity.telefono}");
        }
        /// <summary>
        /// Elimina un telefono de un cliente
        /// </summary>
        /// <param name="idCliente">id de cliente</param>
        /// <param name="telefono">telefono a eliminar</param>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // DELETE api/<ClienteTelefonosController>/5
        [HttpDelete("{idCliente}/{telefono}")]
        public async Task<ActionResult<List<RepartidorTelefonos>>> Delete(int idCliente, int telefono)
        {
            List<RepartidorTelefonos> entityList = new();

            var result = clienteTelefonos.delete($"{idCliente}, {telefono}");

            return result ? Ok(entityList) : BadRequest($"No se ha logrado eliminar a {telefono}");
        }
    }
}
