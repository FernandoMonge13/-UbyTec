using Npgsql;

namespace UbyTECAPI.Models
{
    public class EmpleadoTelefonos : Entity<EmpleadoTelefonos>
    {
        protected override string? atributes
        {
            get => "idEmpleado,telefono";
        }

        protected override string? entity
        {
            get => "empleado_telefonos";
        }
        protected override string? searchAtribute
        {
            get => "idEmpleado";
        }
        public int id { get; set; }
        public int telefono { get; set; }

        protected override EmpleadoTelefonos createEntity(NpgsqlDataReader rd)
        {
            return new EmpleadoTelefonos
            {
                id = Convert.ToInt32(rd["idEmpleado"]),
                telefono = Convert.ToInt32(rd["telefono"])
            };
        }

        protected override string paramsToString()
        {
            return $"{id},{telefono}";
        }

        protected override string getID()
        {
            return id.ToString();
        }
    }
}
