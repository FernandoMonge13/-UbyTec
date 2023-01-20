using Npgsql;

namespace UbyTECAPI.Models
{
    public class Comercio : Entity<Comercio>
    {
        protected override string? atributes
        {
            get => $"idComercio,pass,tipo,nombre,correo,sinpe,solicitud,provincia,canton,distrito";
        }
        protected override string? entity
        {
            get => "comercio";
        }
        protected override string? searchAtribute
        {
            get => "idComercio";
        }
        public int idComercio { get; set; }
        public string? pass { get; set; }
        public string? tipo { get; set; }
        public string? nombre { get; set; }
        public string? correo { get; set; }
        public int sinpe { get; set; }
        public string? solicitud { get; set; }
        public string? provincia { get; set; }
        public string? canton { get; set; }
        public string? distrito { get; set; }

        protected override Comercio createEntity(NpgsqlDataReader rd)
        {
            return new Comercio
            {
                idComercio = Convert.ToInt32(rd["idComercio"]),
                pass = rd["pass"].ToString(),
                tipo = rd["tipo"].ToString(),
                nombre = rd["nombre"].ToString(),
                correo = rd["correo"].ToString(),
                sinpe = Convert.ToInt32(rd["sinpe"]),
                solicitud = rd["solicitud"].ToString(),
                provincia = rd["provincia"].ToString(),
                canton = rd["canton"].ToString(),
                distrito = rd["distrito"].ToString()

            };
        }

        protected override string paramsToString()
        {
            return $"{idComercio},'{pass}','{tipo}','{nombre}','{correo}',{sinpe},'{solicitud}','{provincia}','{canton}','{distrito}'";
        }

        protected override string putParams()
        {
            return $"pass='{pass}',tipo='{tipo}',nombre='{nombre}',correo='{correo}',sinpe={sinpe},solicitud='{solicitud}',provincia='{provincia}',canton='{canton}',distrito='{distrito}'"; ;
        }

        protected override string getID()
        {
            return idComercio.ToString();
        }

        public List<Comercio> createEntityP(NpgsqlDataReader rd)
        {
            return createEntityList(rd);
        }
    }
}
