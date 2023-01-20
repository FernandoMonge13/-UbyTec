using Npgsql;
namespace UbyTECAPI.Models
{
    public abstract class Entity<T>
    {
        private NpgsqlConnection con = new(Connection.Connection.ConnectionString);

        /// <summary>
        /// Atributo que contiene una lista de los atributos que tiene una entidad en forma de string
        /// </summary>
        virtual protected string? atributes { get; set; }

        /// <summary>
        /// Nombre de la entidad
        /// </summary>
        virtual protected string? entity { get; set; }

        /// <summary>
        /// Atributo llave utilizado para realizar búsquedas dentro de la base de datos
        /// </summary>
        virtual protected string? searchAtribute { get; set; }

        /// <summary>
        /// Función encargada de obtener todos las tuplas que contiene la base de datos de la entidad
        /// </summary>
        /// <returns>Retorna una lista de objetos en forma de json
        /// con los parámentros que dio el resultado de la búsqueda</returns>
        public List<T> get()
        {

            con.Open();
            NpgsqlCommand command = new($"SELECT {atributes} FROM get{entity}()", con);
            NpgsqlDataReader rd = command.ExecuteReader();
            List<T> entityList = createEntityList(rd);
            con.Close();
            return entityList;

        }
        /// <summary>
        /// Retorna un resultado a partir de una búsqueda por id en la base de datos
        /// </summary>
        /// <param name="id">Id de la entidad a buscar</param>
        /// <returns></returns>
        public List<T> get(string id)
        {
            con.Open();
            NpgsqlCommand command = new($"SELECT {atributes} FROM get{entity}byid({id})", con);
            NpgsqlDataReader rd = command.ExecuteReader();
            List<T> entityList = createEntityList(rd);
            con.Close();
            return entityList;
        }

        /// <summary>
        /// Agrega una nueva tupla a la base de datos
        /// </summary>
        /// <param name="newEntity">Tupla a agregar a la base de datos</param>
        /// <returns></returns>
        public bool post(Entity<T> newEntity)
        {
            NpgsqlCommand command = new($"CALL add{entity}({newEntity.paramsToString()})", con);

            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        /// <summary>
        /// Realiza una modificación a una tupla
        /// </summary>
        /// <param name="newEntity">Tupla mofificada que se desea actualizar en la base de datos</param>
        /// <returns></returns>
        public bool put(Entity<T> newEntity)
        {

            NpgsqlCommand command = new($"CALL update{entity}({newEntity.paramsToString()})", con);

            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        /// <summary>
        /// Elimina 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool delete(string id)
        {
            NpgsqlCommand command = new($"CALL delete{entity}({id})", con);
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        /// <summary>
        /// Crea una lista de una entidad específica con su contenido
        /// </summary>
        /// <param name="rd">Lector de datos de NpgsqlDataReader</param>
        /// <returns>Retorna una lista del tipo de la entidad de la clase con el resultado de analizar el lector</returns>
        public List<T> createEntityList(NpgsqlDataReader rd)
        {
            List<T> entityList = new();
            while (rd.Read())
            {
                entityList.Add(createEntity(rd));
            }

            return entityList;

        }

        /// <summary>
        /// Clase virtual que debe ser implementada en la clase hija para realizar el paseo del lector 
        /// </summary>
        /// <param name="rd">Reader de pgslq</param>
        /// <returns>Retorna una tupla convertida a objeto tipo</returns>
        protected virtual T createEntity(NpgsqlDataReader rd)
        {
            return createEntity(rd);
        }

        /// <summary>
        /// Método virtual que se debe implementar y desarrollar con los el nombre de los 
        /// parámentros igualados a su valor de la clase
        /// </summary>
        /// <returns>Retorna un string con los datos mencionados</returns>
        protected virtual string paramsToString()
        {
            return paramsToString();
        }

        /// <summary>
        /// Método virtual que se debe impementar para realizar los put dentro de la base de datos
        /// </summary>
        /// <returns>Retorna string con los datos que se utilizan para realizar un put </returns>
        protected virtual string putParams()
        {
            return putParams();
        }

        /// <summary>
        /// Retorna el id o llave de la entidad
        /// </summary>
        /// <returns>string con el nombre del id</returns>
        protected virtual string getID()
        {
            return getID();
        }

        /// <summary>
        /// Retorna los atributos de entidad
        /// </summary>
        /// <returns>atributos que tiene la entidad en forma de string</returns>
        public string getAtributes()
        {
            return atributes;
        }

    }
}