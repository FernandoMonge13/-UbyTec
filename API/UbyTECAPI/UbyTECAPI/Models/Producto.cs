using Npgsql;

namespace UbyTECAPI.Models
{
    public class Producto : Entity<Producto>
    {
        protected override string? atributes
        {
            get => "nombre,precio,categoria,idComercio";
        }
        protected override string? entity
        {
            get => "producto";
        }
        protected override string? searchAtribute
        {
            get => "nombre";
        }
        public string? nombre { get; set; }
        public int precio { get; set; }
        public string? categoria { get; set; }
        public int idComercio { get; set; }

        protected override Producto createEntity(NpgsqlDataReader rd)
        {
            return new Producto
            {
                nombre = rd["nombre"].ToString(),
                precio = Convert.ToInt32(rd["precio"]),
                categoria = rd["categoria"].ToString(),
                idComercio = Convert.ToInt32(rd["idComercio"])
            };
        }

        protected override string paramsToString()
        {
            return $"'{nombre}',{precio},'{categoria}',{idComercio}";
        }

        protected override string putParams()
        {
            return $"nombre='{nombre}',precio={precio},categoria='{categoria}',idComercio={idComercio}";
        }

        protected override string getID()
        {
            return $"'{nombre}'";
        }

    }
}
