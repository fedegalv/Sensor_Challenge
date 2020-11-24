using Sensor_App.Models.Enums;

namespace Sensor_App.Models
{
    public class Seguro
    {
        public int Id { get; set; }
        public EstadoTransito EstadoTransito { get; set; }
        public EstadoTransito EstadoTransitoCargaSuelta { get; set; }
    }
}
