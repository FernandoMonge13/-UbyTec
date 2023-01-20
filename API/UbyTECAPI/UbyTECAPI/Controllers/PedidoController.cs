using Microsoft.AspNetCore.Mvc;
using Npgsql;
using UbyTECAPI.Models;
using UbyTECAPI.Tools;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UbyTECAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private NpgsqlConnection con = new(Connection.Connection.ConnectionString);
        private Pedido pedido = new();
        /// <summary>
        /// Get de pedidos
        /// </summary>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // GET: api/<PedidoController>
        [HttpGet]
        public async Task<ActionResult<List<Pedido>>> Get()
        {
            try
            {
                var entityList = pedido.get();
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
        // GET api/<PedidoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Pedido>>> Get(int id)
        {
            try
            {
                var entityList = pedido.get(id.ToString());
                return Ok(entityList);
            }
            catch (Exception)
            {
                return BadRequest("No se logró conectar a la base de datos");
            }
        }
        /// <summary>
        /// Get pedido por id del comercio
        /// </summary>
        /// <param name="id">id del comercio</param>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // GET api/<PedidoController>/5
        [HttpGet("Comercio/{id}")]
        public async Task<ActionResult<List<Pedido>>> GetByIDComercio(int id)
        {
            try
            {
                con.Open();
                NpgsqlCommand command = new($"SELECT idPedido,direccion," +
                    $"finalizado,repartidor,idCliente,comprobante FROM GetPedidoByIDComercio({id}) where finalizado='Solicitado'", con);
                NpgsqlDataReader rd = command.ExecuteReader();
                List<Pedido> entityList = pedido.createEntityP(rd);

                return Ok(entityList);
            }
            catch (Exception)
            {
                return BadRequest("No se logró conectar a la base de datos");
            }
        }
        /// <summary>
        /// Get de pedidos recientes
        /// </summary>
        /// <param name="id">id del cliente</param>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // GET api/<PedidoController>/5
        [HttpGet("Recientes/{id}")]
        public async Task<ActionResult<List<PedidosCliente>>> GetPedidosRecientes(int id)
        {
            try
            {
                con.Open();
                NpgsqlCommand command = new ($"Select comercio,total,idPedido from Pedidos_Ciente({id})", con);
                NpgsqlDataReader rd = command.ExecuteReader();
                List<PedidosCliente> entityList = new();

                while (rd.Read())
                {
                    entityList.Add(new PedidosCliente
                    {
                        comercio = rd["comercio"].ToString(),
                        total = Convert.ToInt32(rd["total"]),
                        idPedido = Convert.ToInt32(rd["idPedido"])
                    });
                }

                foreach (var item in entityList)
                {
                    item.feedback = MongoConnection.getFeedback(item.idPedido);
                }

                return Ok(entityList);
            }
            catch (Exception)
            {
                return BadRequest("No se logró conectar a la base de datos");
            }
        }

        /// <summary>
        /// Get de pedidos de un cliente
        /// </summary>
        /// <param name="id">id de cliente</param>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // GET api/<PedidoController>/5
        [HttpGet("Cliente/{id}")]
        public async Task<ActionResult<List<Pedido>>> GetByIDCliente(int id)
        {
            try
            {
                con.Open();
                NpgsqlCommand command = new($"SELECT idPedido,direccion," +
                    $"finalizado,repartidor,idCliente,comprobante FROM GetPedidoByIDCliente({id})", con);
                NpgsqlDataReader rd = command.ExecuteReader();
                List<Pedido> entityList = pedido.createEntityP(rd);

                return Ok(entityList);
            }
            catch (Exception)
            {
                return BadRequest("No se logró conectar a la base de datos");
            }
        }
        /// <summary>
        /// Agrega un nuevo pedido
        /// </summary>
        /// <param name="entity">nuevo pedido</param>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // POST api/<PedidoController>
        [HttpPost]
        public async Task<ActionResult<Pedido>> Post(Pedido entity)
        {

            con.Open();
            NpgsqlCommand command = new($"select getNewIDPedido from getNewIDPedido()", con);
            NpgsqlDataReader rd = command.ExecuteReader();
            rd.Read();

            var newIdPedido = Convert.ToInt32(rd["getNewIDPedido"]);

            entity.idPedido = newIdPedido;
            entity.repartidor = null;

            var result = entity.post(entity);


            return result ? Ok(entity) : BadRequest($"No se ha logrado agregar a {entity.idPedido}");
        }
        /// <summary>
        /// Agrega el feedback a un pedido
        /// </summary>
        /// <param name="entity">feedback del pedido</param>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // POST api/<PedidoController>
        [HttpPost("Recientes")]
        public async Task<ActionResult<Pedido>> PostFeedBack(PedidosCliente entity)
        {
            var result = MongoConnection.addFeedback(new MongoFeedback()
            {
                idPedido = entity.idPedido,
                comentario = entity.feedback
            });

            if (!result)
            {
                return BadRequest("No se logró agregar el feedback");
            }
            return Ok(entity);
        }
        /// <summary>
        /// Modifica un pedido
        /// </summary>
        /// <param name="entity">pedido modificado</param>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // PUT api/<PedidoController>/5
        [HttpPut]
        public async Task<ActionResult<List<Pedido>>> Put(Pedido entity)
        {
            con.Open();
            NpgsqlCommand command = new($"select idComercio from (producto_pedido " +
                $"join producto on producto_pedido.producto = producto.nombre) where idPedido={entity.idPedido}", con);
            NpgsqlDataReader rd = command.ExecuteReader();
            rd.Read();
            int idComercio;
            try
            {
                idComercio = Convert.ToInt32(rd[0]);
            }
            catch (Exception)
            {
                return BadRequest("No se encontró un comercio relacionado");
            }


            Console.Write(idComercio);
            con.Close();

            if (entity.finalizado == "Solicitado")
            {
                con.Open();
                Console.WriteLine($"{idComercio},{entity.idPedido}");
                NpgsqlCommand command3 = new($"CALL Asigna_Repartidor({idComercio},{entity.idPedido})", con);
                command3.ExecuteNonQuery();
                con.Close();
                //llama la de asignar
                return Ok(new Pedido());
            }
            else
            if (entity.finalizado == "En Curso")
            {
                con.Open();
                NpgsqlCommand command2 = new($"CALL Finaliza_Pedido({entity.idPedido})", con);
                command2.ExecuteNonQuery();
                con.Close();
                //Finalizar pedido
                return Ok(new Pedido());
            }
            return BadRequest("Esto no debería salir");

        }
        /// <summary>
        /// Elimina un pedido
        /// </summary>
        /// <param name="id">id del pedido a eliminar</param>
        /// <returns>Ok si logra conectar con la base de datos, si no un BadRequest</returns>
        // DELETE api/<PedidoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ProductosPedido>>> Delete(int id)
        {
            List<ProductosPedido> entityList = new();

            var result = pedido.delete(id.ToString());

            return result ? Ok(entityList) : BadRequest($"No se ha logrado eliminar a {id}");
        }
    }
}
