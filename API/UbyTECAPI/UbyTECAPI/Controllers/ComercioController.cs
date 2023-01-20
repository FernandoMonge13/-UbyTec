using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.Core.Operations;
using Npgsql;
using System;
using UbyTECAPI.Models;
using UbyTECAPI.Tools;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UbyTECAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComercioController : ControllerBase
    {
        private NpgsqlConnection con = new(Connection.Connection.ConnectionString);
        private Comercio comercio = new();
        /// <summary>
        /// Get de todos los comercios
        /// </summary>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // GET: api/<ComercioController>
        [HttpGet]
        public async Task<ActionResult<List<Comercio>>> Get()
        {
            try
            {
                var entityList = comercio.get();
                return Ok(entityList);
            }
            catch (Exception)
            {
                return BadRequest("No se logró conectar a la base de datos");
            }
        }
        /// <summary>
        /// Retorna los comercios que se han rechazado
        /// </summary>
        /// <param name="id">id del comercio rechazado</param>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // GET: api/<ComercioController>
        [HttpGet("Razon/{id}")]
        public async Task<ActionResult<List<ComercioRechazado>>> GetRechazados(int id)
        {
            var result = MongoConnection.getRechazado(id);

            return Ok(new List<ComercioRechazado>() { new ComercioRechazado{
                idComercio = result.idComercio,
                comentario = result.comentario
            } });

        }

        /// <summary>
        /// Agrega un comercio a la lista de rechazados
        /// </summary>
        /// <param name="comercioRechazado">comercio a rechazar</param>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        [HttpPost("Razon")]
        public async Task<ActionResult<List<ComercioRechazado>>> PostRechazados(ComercioRechazado comercioRechazado)
        {
            var result = MongoConnection.addRechazado(new MongoComercioRechazado { comentario = comercioRechazado.comentario, idComercio = comercioRechazado.idComercio });
            if (!result)
            {
                return BadRequest("No se logró agregar el feedback")
;
            }
            return Ok(new List<ComercioRechazado>() { comercioRechazado });
        }


        /// <summary>
        /// Retorna las solicitudes de comercios
        /// </summary>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        [HttpGet("solicitudes")]
        public async Task<ActionResult<List<Comercio>>> GetSolicitudes()
        {
            try
            {
                con.Open();
                NpgsqlCommand command = new($"SELECT {comercio.getAtributes()} FROM getsolicitudes()", con);
                NpgsqlDataReader rd = command.ExecuteReader();
                List<Comercio> entityList = comercio.createEntityP(rd);
                con.Close();
                return Ok(entityList);
            }
            catch (Exception)
            {
                return BadRequest("No se logró conectar a la base de datos");
            }
        }
        /// <summary>
        /// Retorna comercio por id
        /// </summary>
        /// <param name="id">id del comercio</param>
        /// <returns></returns>
        // GET api/<ComercioController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Comercio>>> Get(int id)
        {
            try
            {
                var entityList = comercio.get(id.ToString());
                return Ok(entityList);
            }
            catch (Exception)
            {
                return BadRequest("No se logró conectar a la base de datos");
            }
        }
        /// <summary>
        /// Retorna los comercios cercanos
        /// </summary>
        /// <param name="id">id del cliente</param>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // GET api/<ComercioController>/5
        [HttpGet("Cercano/{id}")]
        public async Task<ActionResult<List<Comercio>>> GetCercanos(int id)
        {
            try
            {
                con.Open();
                NpgsqlCommand command = new($"SELECT {comercio.getAtributes()} FROM GetComercioCercanoACliente({id})", con);
                NpgsqlDataReader rd = command.ExecuteReader();
                List<Comercio> entityList = comercio.createEntityP(rd);
                con.Close();
                return Ok(entityList);
            }
            catch (Exception)
            {
                return BadRequest("No se logró conectar a la base de datos");
            }
        }
        /// <summary>
        /// agrega un nuevo comercio
        /// </summary>
        /// <param name="entity">comercio a agregar</param>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // POST api/<ComercioController>
        [HttpPost]
        public async Task<ActionResult<List<Comercio>>> Post(Comercio entity)
        {
            var tempPass = PassGenerator.generatePass();
            entity.pass = tempPass;

            List<Comercio> entityList = new()
            {
                entity
            };

            if (!entity.post(entity))
            {
                return BadRequest($"No se ha logrado agregar a {entity.nombre}");
            }
            if (!EmailSender.sendEmail(entity.correo, entity.nombre, tempPass, "Comercio"))
            {
                var result = entity.delete(entity.idComercio.ToString());
                return BadRequest("Email no válido");
            }
            return Ok(entity);
        }
        /// <summary>
        /// Modifica un comercio
        /// </summary>
        /// <param name="entity">Comercio acualizado</param>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // PUT api/<ComercioController>/5
        [HttpPut]
        public async Task<ActionResult<List<Comercio>>> Put(Comercio entity)
        {
            List<Comercio> entityList = new();
            entityList.Add(entity);

            var result = entity.put(entity);

            return result ? Ok(entityList) : BadRequest($"No se ha logrado actualizar a {entity.nombre}");
        }
        /// <summary>
        /// Elimina un comerio      
        /// </summary>
        /// <param name="id">id del comercio a eliminar</param>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // DELETE api/<ComercioController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Comercio>>> Delete(int id)
        {
            List<Empleado> entityList = new();

            var result = comercio.delete(id.ToString());

            return result ? Ok(entityList) : BadRequest($"No se ha logrado eliminar a {id}");
        }
    }
}