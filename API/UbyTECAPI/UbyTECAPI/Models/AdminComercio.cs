using Npgsql;

namespace UbyTECAPI.Models
{
    public class AdminComercio : Entity<AdminComercio>
    {
        protected override string? atributes
        {
            get => "idAdmin,idComercio,usuario,pass,nombre,apellidos,correo,provincia,canton,distrito";
        }

        protected override string? entity
        {
            get => "admin_comercio";
        }

        protected override string? searchAtribute
        {
            get => $"idAdmin";
        }

        public int idAdmin { get; set; }
        public int idComercio { get; set; }
        public string? usuario { get; set; }
        public string? pass { get; set; }
        public string? nombre { get; set; }
        public string? apellidos { get; set; }
        public string? correo { get; set; }
        public string? provincia { get; set; }
        public string? canton { get; set; }
        public string? distrito { get; set; }

        protected override AdminComercio createEntity(NpgsqlDataReader rd)
        {
            return new AdminComercio
            {
                idAdmin = Convert.ToInt32(rd["idAdmin"]),
                idComercio = Convert.ToInt32(rd["idComercio"]),
                usuario = rd["usuario"].ToString(),
                pass = rd["pass"].ToString(),
                nombre = rd["nombre"].ToString(),
                apellidos = rd["apellidos"].ToString(),
                correo = rd["correo"].ToString(),
                provincia = rd["provincia"].ToString(),
                canton = rd["canton"].ToString(),
                distrito = rd["distrito"].ToString()
            };
        }
        protected override string paramsToString()
        {
            return $"{idAdmin},{idComercio},'{usuario}','{pass}','{nombre}','{apellidos}','{correo}'," +
                $"'{provincia}','{canton}','{distrito}'";
        }

        protected override string putParams()
        {
            return $"idAdmin={idAdmin},idComercio={idComercio},usuario='{usuario}',pass='{pass}',nombre='{nombre}',apellidos='{apellidos}',correo='{correo}'," +
                $"provincia='{provincia}',canton='{canton}',distrito='{distrito}'";
        }

        protected override string getID()
        {
            return idAdmin.ToString();
        }
    }
}
