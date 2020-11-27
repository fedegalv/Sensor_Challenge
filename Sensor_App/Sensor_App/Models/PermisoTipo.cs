using Sensor_App.Models.Enums;

namespace Sensor_App.Models
{
    public class PermisoTipo
    {
        public int Id { get; set; }
        public PermisosEnum Permiso { get; set; }
        public int UserId { get; set; }
      
    }
}
