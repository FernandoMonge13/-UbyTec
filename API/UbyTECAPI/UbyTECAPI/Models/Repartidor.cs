using Npgsql;

namespace UbyTECAPI.Models
{
    public class Repartidor : Entity<Repartidor>
    {

        protected override string? atributes
        {
            get => "usuario,pass,nombre,apellidos,disponible,provincia,canton,distrito,correo";
        }

        protected override string? entity
        {
            get => "repartidor";
        }

        protected override string? searchAtribute
        {
            get => "usuario";
        }

        public string? usuario { get; set; }
        public string? pass { get; set; }
        public string? nombre { get; set; }
        public string? apellidos { get; set; }
        public bool disponible { get; set; }
        public string? provincia { get; set; }
        public string? canton { get; set; }
        public string? distrito { get; set; }
        public string? correo { get; set; }

        protected override Repartidor createEntity(NpgsqlDataReader rd)
        {
            return new Repartidor
            {
                usuario = rd["usuario"].ToString(),
                pass = rd["pass"].ToString(),
                nombre = rd["nombre"].ToString(),
                apellidos = rd["apellidos"].ToString(),
                disponible = Boolean.Parse(rd["disponible"].ToString()),
                provincia = rd["provincia"].ToString(),
                canton = rd["canton"].ToString(),
                distrito = rd["distrito"].ToString(),
                correo = rd["correo"].ToString()
            };
        }
        protected override string paramsToString()
        {
            return $"'{usuario}','{pass}','{nombre}','{apellidos}','{disponible}','{provincia}','{canton}','{distrito}','{correo}'";
        }

        protected override string putParams()
        {
            return $"pass='{pass}',nombre='{nombre}',apellidos='{apellidos}',disponible='{disponible}',provincia='{provincia}',canton='{canton}',distrito='{distrito}'";
        }

        protected override string getID()
        {
            return $"'{usuario}'";
        }
    }

}
