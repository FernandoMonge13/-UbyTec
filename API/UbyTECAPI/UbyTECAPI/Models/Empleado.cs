using Npgsql;

namespace UbyTECAPI.Models
{
    public class Empleado : Entity<Empleado>
    {
        protected override string? atributes
        {
            get => "idEmpleado,usuario,pass,nombre,apellidos,provincia,canton,distrito";
        }

        protected override string? entity
        {
            get => "empleado";
        }
        protected override string? searchAtribute
        {
            get => "idEmpleado";
        }
        public int idEmpleado { get; set; }
        public string? usuario { get; set; }
        public string? pass { get; set; }
        public string? nombre { get; set; }
        public string? apellidos { get; set; }
        public string? provincia { get; set; }
        public string? canton { get; set; }
        public string? distrito { get; set; }

        protected override Empleado createEntity(NpgsqlDataReader rd)
        {
            return new Empleado
            {
                idEmpleado = Convert.ToInt32(rd["idEmpleado"]),
                usuario = rd["usuario"].ToString(),
                pass = rd["pass"].ToString(),
                nombre = rd["nombre"].ToString(),
                apellidos = rd["apellidos"].ToString(),
                provincia = rd["provincia"].ToString(),
                canton = rd["canton"].ToString(),
                distrito = rd["distrito"].ToString()
            };
        }

        protected override string paramsToString()
        {
            return $"{idEmpleado},'{usuario}','{pass}','{nombre}','{apellidos}','{provincia}','{canton}','{distrito}'";
        }

        protected override string putParams()
        {
            return $"usuario='{usuario}',pass='{pass}',nombre='{nombre}',apellidos='{apellidos}',provincia='{provincia}',canton='{canton}',distrito='{distrito}'";
        }

        protected override string getID()
        {
            return idEmpleado.ToString();
        }

    }
}
