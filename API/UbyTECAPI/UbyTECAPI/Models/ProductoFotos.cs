using Npgsql;

namespace UbyTECAPI.Models
{
    public class ProductoFotos: Entity<ProductoFotos>
    {
        protected override string? atributes { get => "producto, foto"; }
        protected override string? entity { get => "producto_fotos"; }
        protected override string? searchAtribute { get => "producto"; }

        public string? producto { get; set; }
        public string? foto { get; set; }
        public string? fotoData { get; set; }
        public string? thumbnails { get; set; }

        protected override ProductoFotos createEntity(NpgsqlDataReader rd)
        {
            return new ProductoFotos
            {
                producto = rd["producto"].ToString(),
                foto = rd["foto"].ToString()
            };
        }

        protected override string paramsToString()
        {
            return $"'{producto}', '{foto}'";
        }

        protected override string putParams()
        {
            return $"producto='{producto}', foto='{foto}'";
        }

        protected override string getID()
        {
            return $"'{producto}'";
        }

    }

}
