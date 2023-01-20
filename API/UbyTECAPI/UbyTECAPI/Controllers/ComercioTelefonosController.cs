using Microsoft.AspNetCore.Mvc;
using UbyTECAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UbyTECAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComercioTelefonosController : ControllerBase
    {
        private ComercioTelefonos comercioTelefonos = new();

        /// <summary>
        /// Get para telefnos de comercio
        /// </summary>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // GET: api/<ComercioTelefonosController>
        [HttpGet]
        public async Task<ActionResult<List<ComercioTelefonos>>> Get()
        {
            try
            {
                var entityList = comercioTelefonos.get();
                return Ok(entityList);
            }
            catch (Exception)
            {
                return BadRequest("No se logró conectar a la base de datos");
            }
        }
        /// <summary>
        /// Retorna un telefono por id
        /// </summary>
        /// <param name="idComercio">id del comercio</param>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // GET api/<ComercioTelefonosController>/5
        [HttpGet("{idComercio}")]
        public async Task<ActionResult<List<ComercioTelefonos>>> Get(int idComercio)
        {
            try
            {
                var entityList = comercioTelefonos.get(idComercio.ToString());
                return Ok(entityList);
            }
            catch (Exception)
            {
                return BadRequest("No se logró conectar a la base de datos");
            }
        }
        /// <summary>
        /// Agrega un nuevo telefono
        /// </summary>
        /// <param name="entity">Entidad con el nuevo telefono</param>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // POST api/<ComercioTelefonosController>
        [HttpPost]
        public async Task<ActionResult<List<ComercioTelefonos>>> Post(ComercioTelefonos entity)
        {
            List<ComercioTelefonos> entityList = new();
            entityList.Add(entity);

            var result = entity.post(entity);

            return result ? Ok(entityList) : BadRequest($"No se ha logrado agregar a {entity.telefono}");
        }

        /// <summary>
        /// Elimina un telefono
        /// </summary>
        /// <param name="idComercio">id del comrcio</param>
        /// <param name="telefono">telefono a eliminar</param>
        /// <returns></returns>
        // DELETE api/<ComercioTelefonosController>/5
        [HttpDelete("{idComercio}/{telefono}")]
        public async Task<ActionResult<List<RepartidorTelefonos>>> Delete(int idComercio, int telefono)
        {
            List<RepartidorTelefonos> entityList = new();

            var result = comercioTelefonos.delete($"{idComercio}, {telefono}");

            return result ? Ok(entityList) : BadRequest($"No se ha logrado eliminar a {telefono}");
        }
    }
}
