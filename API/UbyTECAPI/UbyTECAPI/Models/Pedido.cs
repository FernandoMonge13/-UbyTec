using Npgsql;

namespace UbyTECAPI.Models
{
    public class Pedido : Entity<Pedido>
    {
        protected override string? atributes
        {
            get => "idPedido,direccion,finalizado,repartidor,idCliente,comprobante";
        }
        protected override string? entity
        {
            get => "pedido";
        }
        protected override string? searchAtribute
        {
            get => "idPedido";
        }
        public int idPedido { get; set; }
        public string? direccion { get; set; }
        public string? finalizado { get; set; }
        public string? repartidor { get; set; }
        public int idCliente { get; set; }
        public string? comprobante { get; set; }

        protected override Pedido createEntity(NpgsqlDataReader rd)
        {
            return new Pedido
            {
                idPedido = Convert.ToInt32(rd["idPedido"]),
                direccion = rd["direccion"].ToString(),
                finalizado = rd["finalizado"].ToString(),
                repartidor = rd["repartidor"].ToString(),
                idCliente = Convert.ToInt32(rd["idCliente"]),
                comprobante = rd["comprobante"].ToString(),
            };
        }

        protected override string paramsToString()
        {
            return $"{idPedido},'{direccion}','{finalizado}','{repartidor}',{idCliente},'{comprobante}'";
        }

        protected override string putParams()
        {
            return $"direccion='{direccion}',finalizado='{finalizado}',repartidor='{repartidor}',idCliente={idCliente},comprobante='{comprobante}'";
        }

        protected override string getID()
        {
            return idPedido.ToString();
        }

        public List<Pedido> createEntityP(NpgsqlDataReader rd)
        {
            return createEntityList(rd);
        }
    }
}
