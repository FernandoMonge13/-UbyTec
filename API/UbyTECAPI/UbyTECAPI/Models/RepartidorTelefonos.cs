using Npgsql;

namespace UbyTECAPI.Models
{
    public class RepartidorTelefonos : Entity<RepartidorTelefonos>
    {
        protected override string? atributes
        {
            get => "usuarioRep,telefono";
        }

        protected override string? entity
        {
            get => "repartidor_telefonos";
        }

        protected override string? searchAtribute
        {
            get => "usuarioRep";
        }
        public string? id { get; set; }
        public int telefono { get; set; }

        protected override RepartidorTelefonos createEntity(NpgsqlDataReader rd)
        {
            return new RepartidorTelefonos
            {
                id = rd["usuarioRep"].ToString(),
                telefono = Convert.ToInt32(rd["telefono"])
            };
        }
        protected override string paramsToString()
        {
            return $"'{id}',{telefono}";
        }

        protected override string getID()
        {
            return $"'{id}'";
        }
    }
}
