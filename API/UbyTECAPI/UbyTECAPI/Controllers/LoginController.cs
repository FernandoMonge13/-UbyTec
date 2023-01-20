using Microsoft.AspNetCore.Mvc;
using UbyTECAPI.Models;
using Npgsql;
using UbyTECAPI.Connection;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UbyTECAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private NpgsqlConnection con = new NpgsqlConnection(Connection.Connection.ConnectionString);
        private Empleado empleado = new();
        private Comercio comercio = new();
        private Cliente cliente = new();
        /// <summary>
        /// Login para empleado
        /// </summary>
        /// <param name="id">id del admin</param>
        /// <param name="pass">contraseña</param>
        /// <returns>true si inicia, false si no</returns>
        // GET api/<LoginController>/5
        //EMPLADO
        [HttpGet("empleado/{id}/{pass}")]
        public async Task<ActionResult<bool>> LoginAdmin(int id,string pass)
        {
            con.Open();
            NpgsqlCommand command = new($"SELECT validaempleado FROM validaempleado({id},'{pass}')", con);
            var rd = command.ExecuteReader();
            rd.Read();
            var result = Convert.ToInt32(rd[0]);
            return result == 1 ? Ok(true) : BadRequest(false);
        }
        /// <summary>
        /// Login para comercio
        /// </summary>
        /// <param name="id">id del comercio</param>
        /// <param name="pass">contraseña</param>
        /// <returns>true si inicia, false si no</returns>
        // GET api/<LoginController>/5
        //COMERCIO
        [HttpGet("comercio/{id}/{pass}")]
        public async Task<ActionResult<bool>> LoginComercio(int id, string pass)
        {
            con.Open();
            NpgsqlCommand command = new($"SELECT validacomercio FROM validacomercio({id},'{pass}')", con);
            var rd = command.ExecuteReader();
            rd.Read();
            var result = Convert.ToInt32(rd[0]);
            return result == 1 ? Ok(true) : BadRequest(false);

        }
        /// <summary>
        /// Login para comercio
        /// </summary>
        /// <param name="id">id del comercio</param>
        /// <param name="pass">contraseña</param>
        /// <returns>true si inicia, false si no</returns>
        // GET api/<LoginController>/5
        //Cliente
        [HttpGet("cliente/{id}/{pass}")]
        public async Task<ActionResult<bool>> LoginCliente(int id, string pass)
        {
            con.Open();
            NpgsqlCommand command = new($"SELECT validacliente FROM validacliente({id},'{pass}')", con);
            var rd = command.ExecuteReader();
            rd.Read();
            var result = Convert.ToInt32(rd[0]);
            return result == 1? Ok(true) : BadRequest(false);
        }

    }
}
