using Npgsql;

namespace UbyTECAPI.Models
{
    public class ProductoThumbnail:Producto
    {

        public ProductoThumbnail(Producto producto)
        {
            nombre = producto.nombre;
            precio = producto.precio;
            categoria = producto.categoria;
            idComercio = producto.idComercio;
        }
        public string? data { get; set; }

    }
}
