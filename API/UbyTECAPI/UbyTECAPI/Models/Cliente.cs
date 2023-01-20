using Npgsql;

namespace UbyTECAPI.Models
{
    public class Cliente : Entity<Cliente>
    {

        protected override string? atributes
        {
            get => "idCliente,usuario,pass,nombre,apellidos,fechaNac,provincia,canton,distrito";
        }

        protected override string? entity
        {
            get => "cliente";
        }

        protected override string? searchAtribute
        {
            get => "idCliente";
        }

        public int idCliente { get; set; }
        public string? usuario { get; set; }
        public string? pass { get; set; }
        public string? nombre { get; set; }
        public string? apellidos { get; set; }
        public string? fechaNac { get; set; }
        public string? provincia { get; set; }
        public string? canton { get; set; }
        public string? distrito { get; set; }

        protected override Cliente createEntity(NpgsqlDataReader rd)
        {
            return new Cliente
            {
                idCliente = Convert.ToInt32(rd["idCliente"]),
                usuario = rd["usuario"].ToString(),
                pass = rd["pass"].ToString(),
                nombre = rd["nombre"].ToString(),
                apellidos = rd["apellidos"].ToString(),
                fechaNac = rd["fechaNac"].ToString(),
                provincia = rd["provincia"].ToString(),
                canton = rd["canton"].ToString(),
                distrito = rd["distrito"].ToString()
            };
        }
        protected override string paramsToString()
        {
            return $"{idCliente},'{usuario}','{pass}','{nombre}','{apellidos}','{fechaNac}'," +
                $"'{provincia}','{canton}','{distrito}'";
        }

        protected override string putParams()
        {
            return $"usuario='{usuario}',pass='{pass}',nombre='{nombre}',apellidos='{apellidos}',fechaNac='{fechaNac}'," +
                    $"provincia='{provincia}',canton='{canton}',distrito='{distrito}'";
        }

        protected override string getID()
        {
            return idCliente.ToString();
        }


    }
}
