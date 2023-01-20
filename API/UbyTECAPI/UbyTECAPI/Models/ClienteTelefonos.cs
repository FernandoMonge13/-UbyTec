using Npgsql;

namespace UbyTECAPI.Models
{
    public class ClienteTelefonos : Entity<ClienteTelefonos>
    {
        protected override string? atributes
        {
            get => "idCliente,telefono";
        }
        protected override string? entity
        {
            get => "cliente_telefonos";
        }
        protected override string? searchAtribute
        {
            get => "idCliente";
        }
        public int id { get; set; }
        public int telefono { get; set; }

        protected override ClienteTelefonos createEntity(NpgsqlDataReader rd)
        {
            return new ClienteTelefonos
            {
                id = Convert.ToInt32(rd["idCliente"]),
                telefono = Convert.ToInt32(rd["telefono"])
            };
        }

        protected override string paramsToString()
        {
            return $"{id},{telefono}";
        }

        protected override string putParams()
        {
            return $"idCliente={id},telefono={telefono}"; ;
        }

        protected override string getID()
        {
            return id.ToString();
        }
    }
}
