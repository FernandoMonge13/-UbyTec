using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using UbyTECAPI.Connection;
using UbyTECAPI.Models;

namespace UbyTECAPI.Tools
{
    /// <summary>
    /// Clase encargada del manejo de conexiones con la base de datos de Mongo
    /// </summary>
    public class MongoConnection
    {
        private static MongoClient client = new MongoClient(Connection.Connection.mongoString);
        private static string defaultImage = "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAZABkAAD/7AARRHVja3kAAQAEAAAAPAAA/9sAQwAEAwMEAwMEBAQEBQUEBQcLBwcGBgcOCgoICxAOEREQDhAPEhQaFhITGBMPEBYfFxgbGx0dHREWICIfHCIaHB0c/8AACwgAyADIAQERAP/EABsAAQADAQEBAQAAAAAAAAAAAAADBAUGAgEI/8QANRABAAECAgYIBQQCAwAAAAAAAAECAwRTBREUFXKSITE0UXGRscESEyIyQSNCYdGBoTNiov/aAAgBAQAAPwD9tAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA+VV00RrqqimO+Z1I9ps51vmg2mznW+aDabOdb5oNps51vmg2mznW+aDabOdb5oNps51vmg2mznW+aDabOdb5oNps51vmg2mznW+aHuium5GuiqmqI7p1vQAAAixN+MNYruz0/DHRHfLm5+fjr09dy5P47v6SbrxeTPnBuvF5M+cG68Xkz5wbrxeTPnBuvF5M+cG68Xkz5wbrxeTPnBuvF5M+cG68Xkz5wbrxeTPnBuvF5M+cI/hv4K7rmKrdcdPj/bosHiIxWHouatUz0THdKcAABR0x2Cvip9VPQUfqX5/Pwx6toAAAY+nY6LH+fZPoXsc8c+zRAAAUdMdhr4qfVT0D99/hj1bQPNy5Taoqrrqimmnrl5s37eIt/Hbq+KlIADI071WPGr2TaF7HPHPs0QAAFHTHYa+Kn1U9A/ff4Y9W0DE0zivirixTPRT01eP4hBovGbNf+Gqf06+if4nvdEADI071WPGr2TaF7HPHPs0QAAFHTHYa+Kn1U9A/ff4Y9W0IsTfpw1iu7V+2OiO+XLV1TXVVVVOuqqdcy8t/ROM+fa+VVP6luPOGiAMjTvVY8avZNoXsc8c+zRAAAUdMdhr4qfVT0D99/hj1bQwtMYr5t6LNM/Tb6/5lmCSxeqw92m5RPTT/t1Nm7TftU3KJ+mqNbP0tjflUfJt1aq6umqY/EItDYyZqnD3KpnX00TM/wCmwMjTvVY8avZNoXsc8c+zRAAAUdMdhr4qfVT0D99/hj1bSvjMTGFw9dz93VTHfLmJmZmZmdcz063wIjXOqOueh0n0aLwXfNP/AKqc7cuVXa6q6p11VTrmXyiqbdUVUzqqidcS6nCYiMVYpuR1z1x3SmZGneqx41eybQvY5459miAAAo6Y7DXxU+qnoH77/DHq2nPaVxXz8RNFM/Rb6PGfyoAPdd65dimK66qop6omep4GhonF/IvTbqn9O50eE/h0DI071WPGr2TaF7HPHPs0QAAFHTHYa+Kn1U9A/ff4Y9Wjj8ROGwtdcfdP00+MuYAAB0ujcTOKw0VVffT9NX8qeneqx41eybQvY5459miAAAo6X7DXxU+qnoL/AJL/AAx6ti5bou0TRXTFVM/iUG7sLkUeRu7C5FHkbuwuRR5G7sLkUeRu7C5FHkbuwuRR5G7sLkUeRu7C5FHkbvwuRR5JrVqizT8NuiKae6GVp3qsf59k+hexzxz7NEAABDirG04e5a16vijon+XOU1XsDenVrt3I6PH+029sXmRywb2xeZHLBvbF5kcsG9sXmRywb2xeZHLBvbF5kcsG9sXmRywb2xeZHLBvbF5kcsG9sXmRywb2xeZHLCGu5ext2NczXXPRER+HRYLD7LhqLczrmOmZ/lOAAAPNdqi7GquimqP+0a0WxYbIt8psWGyLfKbFhsi3ymxYbIt8psWGyLfKbFhsi3ymxYbIt8psWGyLfKbFhsi3ymxYbIt8psWGyLfKkt2rdmNVuimnhjU9gAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA/9k=";

        /// <summary>
        /// Agrega una nueva imagen a la base de datos mongo
        /// </summary>
        /// <param name="imageData">Objeto con parámentros para agregar una imagen de alta resolución</param>
        /// <param name="mongoThumbnails">Objeto con parámentros para agregar una imagen de baja calidad</param>
        /// <returns></returns>
        public static bool addImage(MongoImage imageData, MongoThumbnails mongoThumbnails)
        {
            try
            {
                var database = client.GetDatabase("UbyTEC");

                var imagesDB = database.GetCollection<MongoImage>("images");

                imagesDB.InsertOne(imageData);

                var thumbnailsDB = database.GetCollection<MongoThumbnails>("thumbnails");

                thumbnailsDB.InsertOne(mongoThumbnails);

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }
        /// <summary>
        /// Retorna una imagen que está en la base de datos a partir de su nombre y del producto al que pertenece
        /// </summary>
        /// <param name="nombreImagen_">Nombre o identificador de la imagen</param>
        /// <param name="producto_">Nombre del producto al que pertenece la imagen</param>
        /// <returns></returns>
        public static MongoImage getImage(string nombreImagen_, string producto_)
        {
            var database = client.GetDatabase("UbyTEC");

            var imagesDB = database.GetCollection<MongoImage>("images");

            var listResult = imagesDB.Find(d => d.nombreImagen == nombreImagen_ && d.producto == producto_).ToList().First();

            return listResult;
        }

        /// <summary>
        /// Retorna una imagen en baja calidad para previsualizaciones
        /// </summary>
        /// <param name="nombreImagen_">Nombre de la imangen a buscar</param>
        /// <param name="producto_">Nombre del producto al que pertenece la imagen</param>
        /// <returns></returns>
        public static MongoThumbnails getThumbnails(string nombreImagen_, string producto_)
        {
            var database = client.GetDatabase("UbyTEC");

            var imagesDB = database.GetCollection<MongoThumbnails>("thumbnails");

            var listResult = imagesDB.Find(d => d.nombreImagen == nombreImagen_ && d.producto == producto_).ToList().First();

            return listResult;
        }

        /// <summary>
        /// Retorna la primera imagen en baja calidad de un determinado producto
        /// </summary>
        /// <param name="nombreproducto_">Nombre del producto del que se queire buscar la imagen</param>
        /// <returns></returns>
        public static MongoThumbnails getThumbnails(string nombreproducto_)
        {
            var database = client.GetDatabase("UbyTEC");

            var imagesDB = database.GetCollection<MongoThumbnails>("thumbnails");
            try
            {
                var listResult = imagesDB.Find(d => d.producto == nombreproducto_).ToList().First();
                return listResult;
            }
            catch (Exception)
            {
                return new MongoThumbnails() { thumbnails = defaultImage };

            }
        }
        /// <summary>
        /// Elimina una imagen de la base de datos mongo, también elimina su imagen pequeña o thumbnail
        /// </summary>
        /// <param name="nombreImagen_">Nombre de la imagen que se desea buscar</param>
        /// <param name="producto_">Nombre del producto al que pertenece la imagen</param>
        /// <returns></returns>
        public static bool deleteImage(string nombreImagen_, string producto_)
        {
            try
            {
                var database = client.GetDatabase("UbyTEC");

                var imagesDB = database.GetCollection<MongoImage>("images");
                var thumbnailsDB = database.GetCollection<MongoThumbnails>("thumbnails");

                imagesDB.DeleteOne(d => d.nombreImagen == nombreImagen_ && d.producto == producto_);
                thumbnailsDB.DeleteOne(d => d.nombreImagen == nombreImagen_ && d.producto == producto_);

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        /// <summary>
        /// Retorna el feedback dado a un pedido específico
        /// </summary>
        /// <param name="idPedido">Id del pedido al cual se desea obtener el feedback</param>
        /// <returns></returns>

        public static string getFeedback(int idPedido)
        {
            var database = client.GetDatabase("UbyTEC");

            var feedbackDB = database.GetCollection<MongoFeedback>("feedback");
            try
            {
                MongoFeedback listResult = feedbackDB.Find(d => d.idPedido == idPedido).ToList().First();
                return listResult.comentario;
            }
            catch (Exception)
            {
                return "Sin comentario";
            }
        }
        /// <summary>
        /// Agrega el feedback a un pedido específico
        /// </summary>
        /// <param name="mongoFB">Clase con parámentros necesarios para agreagar el feedback a la base de datos</param>
        /// <returns></returns>
        public static bool addFeedback(MongoFeedback mongoFB)
        {
            try
            {
                var database = client.GetDatabase("UbyTEC");

                var feedBK = database.GetCollection<MongoFeedback>("feedback");

                feedBK.InsertOne(mongoFB);

                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        /// <summary>
        /// Retorna el comentario dado a un comercio que fue rechazado
        /// </summary>
        /// <param name="idComercio">Id del comercio rechazado al cual se desea realizar la búsqueda</param>
        /// <returns></returns>
        public static MongoComercioRechazado getRechazado(int idComercio)
        {
            var database = client.GetDatabase("UbyTEC");

            var rechazadosBD = database.GetCollection<MongoComercioRechazado>("comercios-rechazados");
            try
            {
                MongoComercioRechazado listResult = rechazadosBD.Find(d => d.idComercio == idComercio).ToList().First();
                return listResult;
            }
            catch (Exception)
            {
                return new MongoComercioRechazado() { comentario = "Sin comentario", idComercio = idComercio };
            }
        }
        /// <summary>
        /// Agrega un comercio rechazado a la base de datos mongo, así como el comentario con la razón de su rechazo
        /// </summary>
        /// <param name="mongoR">Clase que tiene los parámentros para agregar el rechazo a la base de datos</param>
        /// <returns></returns>
        public static bool addRechazado(MongoComercioRechazado mongoR)
        {
            try
            {
                var database = client.GetDatabase("UbyTEC");

                var rechazadoDB = database.GetCollection<MongoComercioRechazado>("comercios-rechazados");

                rechazadoDB.InsertOne(mongoR);

                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

    }

    /// <summary>
    /// Clase esquema encargada de tener los parámentros necesarios para el manejo de las imágenes que se almacenan en mongo
    /// </summary>
    public class MongoImage
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? nombreImagen { get; set; }
        public string? producto { get; set; }
        public string? imagenData { get; set; }
    }

    /// <summary>
    /// Clase esquema para el manejo de las imagenes para previsualizaciones
    /// </summary>
    public class MongoThumbnails
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? nombreImagen { get; set; }
        public string? producto { get; set; }
        public string? thumbnails { get; set; }
    }

    /// <summary>
    /// Clase encargada del manejo del feedback 
    /// </summary>
    public class MongoFeedback
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public int idPedido { get; set; }
        public string? comentario { get; set; }
    }

    /// <summary>
    /// Clase esquema encargada de manejar los parámentros del rechazo de comercios
    /// </summary>
    public class MongoComercioRechazado
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public int idComercio { get; set; }
        public string? comentario { get; set; }
    }
}
