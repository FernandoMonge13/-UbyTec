using Microsoft.AspNetCore.Mvc;
using UbyTECAPI.Models;
using UbyTECAPI.Tools;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UbyTECAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepartidorController : ControllerBase
    {
        private Repartidor repartidor = new();

        /// <summary>
        /// Get de repartidor
        /// </summary>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // GET: api/<RepartidorController>
        [HttpGet]
        public async Task<ActionResult<List<Repartidor>>> Get()
        {
            try
            {
                List<Repartidor> entityList = repartidor.get();
                return Ok(entityList);
            }
            catch (Exception)
            {
                return BadRequest("No se logró conectar a la base de datos");
            }
        }

        /// <summary>
        /// Get de repartidor por usuario
        /// </summary>
        /// <param name="usuario">nombre de usuario</param>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // GET api/<RepartidorController>/5
        [HttpGet("{usuario}")]
        public async Task<ActionResult<List<Repartidor>>> Get(string usuario)
        {
            try
            {
                List<Repartidor> entityList = repartidor.get($"'{usuario}'");
                return Ok(entityList);
            }
            catch (Exception)
            {
                return BadRequest("No se logró conectar a la base de datos");
            }
        }

        /// <summary>
        /// Agrega un repartidor
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // POST api/<RepartidorController>
        [HttpPost]
        public async Task<ActionResult<List<Repartidor>>> Post(Repartidor entity)
        {
            var tempPass = PassGenerator.generatePass();
            entity.pass = tempPass;


            List<Repartidor> entityList = new()
            {
                entity
            };

            if (!entity.post(entity))
            {
                return BadRequest($"No se ha logrado agregar a {entity.nombre}");
            }
            if (!EmailSender.sendEmail(entity.correo, entity.nombre, tempPass, "Repartidor"))
            {
                var result = entity.delete($"'{entity.usuario}'");
                return BadRequest("Email no válido");
            };

            return Ok(entityList);

        }
        /// <summary>
        /// Modifica un repartidor
        /// </summary>
        /// <param name="entity">repartidor actualizado</param>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // PUT api/<RepartidorController>/5
        [HttpPut]
        public async Task<ActionResult<List<Repartidor>>> Put(Repartidor entity)
        {
            List<Repartidor> entityList = new();
            entityList.Add(entity);

            var result = entity.put(entity);

            return result ? Ok(entityList) : BadRequest($"No se ha logrado actualizar a {entity.usuario}");
        }

        /// <summary>
        /// Elimina un repartidor
        /// </summary>
        /// <param name="usuario">nombre del repartidor</param>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // DELETE api/<RepartidorController>/5
        [HttpDelete("{usuario}")]
        public async Task<ActionResult<List<Repartidor>>> Delete(string usuario)
        {
            List<Empleado> entityList = new();

            var result = repartidor.delete($"'{usuario}'");

            return result ? Ok(entityList) : BadRequest($"No se ha logrado eliminar a {usuario}");
        }
    }
}
