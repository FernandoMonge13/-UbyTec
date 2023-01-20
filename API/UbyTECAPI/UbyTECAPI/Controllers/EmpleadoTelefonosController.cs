using Microsoft.AspNetCore.Mvc;
using UbyTECAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UbyTECAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoTelefonosController : ControllerBase
    {
        private EmpleadoTelefonos empleadoTelefonos = new();

        /// <summary>
        /// Get para telefonos de empleados
        /// </summary>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // GET: api/<EmpleadoTelefonosController>
        [HttpGet]
        public async Task<ActionResult<List<EmpleadoTelefonos>>> Get()
        {
            try
            {
                var entityList = empleadoTelefonos.get();
                return Ok(entityList);
            }
            catch (Exception)
            {
                return BadRequest("No se logró conectar a la base de datos");
            }
        }

        /// <summary>
        /// Get telefonos por id
        /// </summary>
        /// <param name="id">id del emplea</param>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // GET api/<EmpleadoTelefonosController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<EmpleadoTelefonos>>> Get(int id)
        {
            try
            {
                var entityList = empleadoTelefonos.get(id.ToString());
                return Ok(entityList);
            }
            catch (Exception)
            {
                return BadRequest("No se logró conectar a la base de datos");
            }
        }
        /// <summary>
        /// Agrega un nuevo teléfono
        /// </summary>
        /// <param name="entity">Nuevo teléfono</param>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // POST api/<EmpleadoTelefonosController>
        [HttpPost]
        public async Task<ActionResult<List<EmpleadoTelefonos>>> Post(EmpleadoTelefonos entity)
        {
            List<EmpleadoTelefonos> entityList = new();
            entityList.Add(entity);

            var result = entity.post(entity);

            return result ? Ok(entityList) : BadRequest($"No se ha logrado agregar a {entity.telefono}");
        }

        /// <summary>
        /// Elimina un telefono del empleado
        /// </summary>
        /// <param name="idEmpleado">id del empleado</param>
        /// <param name="telefono">telefono a eliminar</param>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // DELETE api/<EmpleadoTelefonosController>/5
        [HttpDelete("{idEmpleado}/{telefono}")]
        public async Task<ActionResult<List<EmpleadoTelefonos>>> Delete(int idEmpleado, int telefono)
        {
            List<EmpleadoTelefonos> entityList = new();

            var result = empleadoTelefonos.delete($"{idEmpleado}, {telefono}");

            return result ? Ok(entityList) : BadRequest($"No se ha logrado eliminar a {telefono}");
        }
    }
}
