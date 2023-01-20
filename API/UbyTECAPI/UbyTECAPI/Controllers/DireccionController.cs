using Microsoft.AspNetCore.Mvc;
using Npgsql;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UbyTECAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DireccionController : ControllerBase
    {
        private NpgsqlConnection con = new(Connection.Connection.ConnectionString);

        /// <summary>
        /// Retorna todas las provincias que se tienen en la base de datos
        /// </summary>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // GET: api/<DireccionController>
        [HttpGet("Provincia")]
        public async Task<ActionResult<List<string>>> GetProvincia()
        {
            con.Open();
            NpgsqlCommand command = new($"select distinct provincia from direcciones", con);
            NpgsqlDataReader rd = command.ExecuteReader();

            var provinciaList = new List<string>();

            while (rd.Read())
            {
                provinciaList.Add(rd["provincia"].ToString());
            }
            con.Close();

            return Ok(provinciaList);
        }

        /// <summary>
        /// Retorna los cantones de una provincia
        /// </summary>
        /// <param name="provincia">nombre de la provincia</param>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        [HttpGet("{provincia}")]
        public async Task<ActionResult<List<string>>> GetCanton(string provincia)
        {
            con.Open();
            NpgsqlCommand command = new($"select distinct provincia,canton from direcciones where provincia = '{provincia}'", con);
            NpgsqlDataReader rd = command.ExecuteReader();

            var provinciaList = new List<string>();

            while (rd.Read())
            {
                provinciaList.Add(rd["canton"].ToString());
            }
            con.Close();

            return Ok(provinciaList);
        }
        /// <summary>
        /// Retorna una distrito a partir de una provincia y un cantón
        /// </summary>
        /// <param name="provincia">provincia a buscar</param>
        /// <param name="canton">canton a buscar</param>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        [HttpGet("{provincia}/{canton}")]
        public async Task<ActionResult<List<string>>> GetDistrito(string provincia, string canton)
        {
            con.Open();
            NpgsqlCommand command = new($"select provincia,canton,distrito from direcciones where provincia = '{provincia}' AND canton= '{canton}'", con);
            NpgsqlDataReader rd = command.ExecuteReader();

            var provinciaList = new List<string>();

            while (rd.Read())
            {
                provinciaList.Add(rd["distrito"].ToString());
            }
            con.Close();

            return Ok(provinciaList);
        }
    }
  
}
