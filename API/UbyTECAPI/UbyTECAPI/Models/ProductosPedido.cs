using Npgsql;

namespace UbyTECAPI.Models
{
    public class ProductosPedido : Entity<ProductosPedido>
    {
        protected override string? atributes
        {
            get => "idPedido,producto,cantidad";
        }
        protected override string? entity
        {
            get => "producto_pedido";
        }
        protected override string? searchAtribute
        {
            get => "idPedido";
        }

        public int idPedido { get; set; }
        public string? producto { get; set; }
        public int cantidad { get; set; }

        protected override ProductosPedido createEntity(NpgsqlDataReader rd)
        {
            return new ProductosPedido
            {
                idPedido = Convert.ToInt32(rd["idPedido"]),
                producto = rd["producto"].ToString(),
                cantidad = Convert.ToInt32(rd["cantidad"])
            };
        }

        protected override string paramsToString()
        {
            return $"{idPedido},'{producto}',{cantidad}";
        }

        protected override string putParams()
        {
            return $"idPedido={idPedido},producto='{producto}',cantidad={cantidad}";
        }
        protected override string getID()
        {
            return idPedido.ToString();
        }
    }
}
