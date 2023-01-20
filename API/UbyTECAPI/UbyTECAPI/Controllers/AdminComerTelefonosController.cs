using Microsoft.AspNetCore.Mvc;
using UbyTECAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UbyTECAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminComerTelefonosController : ControllerBase
    {
        private AdminComerTelefonos adminComerTelefonos = new();

        /// <summary>
        /// Get para los telefonos de los administradores de comercios
        /// </summary>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // GET: api/<AdminComerTelefonosController>
        [HttpGet]
        public async Task<ActionResult<List<AdminComerTelefonos>>> Get()
        {
            try
            {
                var entityList = adminComerTelefonos.get();
                return Ok(entityList);
            }
            catch (Exception)
            {
                return BadRequest("No se logró conectar a la base de datos");
            }
        }
        /// <summary>
        /// Get para comercio admin telefonos por id
        /// </summary>
        /// <param name="idAdmin">id a buscar</param>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // GET api/<AdminComerTelefonosController>/5
        [HttpGet("{idAdmin}")]
        public async Task<ActionResult<List<AdminComerTelefonos>>> Get(int idAdmin)
        {
            try
            {
                var entityList = adminComerTelefonos.get($"{idAdmin}");
                return Ok(entityList);
            }
            catch (Exception)
            {
                return BadRequest("No se logró conectar a la base de datos");
            }
        }
        /// <summary>
        /// Método post para admin controller, agrega un nuevo telefono admin
        /// </summary>
        /// <param name="entity">entidad a agregar</param>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // POST api/<AdminComerTelefonosController>
        [HttpPost]
        public async Task<ActionResult<List<AdminComerTelefonos>>> Post(AdminComerTelefonos entity)
        {
            List<AdminComerTelefonos> entityList = new();
            entityList.Add(entity);

            var result = entity.post(entity);

            return result ? Ok(entityList) : BadRequest($"No se ha logrado agregar a {entity.telefono}");
        }
        /// <summary>
        /// Elimina un adminComerTelefonos
        /// </summary>
        /// <param name="idAdmin">id del admin</param>
        /// <param name="telefono">telefono a eliminar</param>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // PUT api/<AdminComerTelefonosController>/5
        [HttpDelete("{idAdmin}/{telefono}")]
        public async Task<ActionResult<List<AdminComerTelefonos>>> Delete(int idAdmin, int telefono)
        {
            List<AdminComerTelefonos> entityList = new();

            var result = adminComerTelefonos.delete($"{idAdmin}, {telefono}");

            return result ? Ok(entityList) : BadRequest($"No se ha logrado eliminar a {telefono}");
        }
    }
}
