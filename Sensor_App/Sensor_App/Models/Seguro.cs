using Sensor_App.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sensor_App.Models
{
    public class Seguro
    {
        public int SeguroId { get; set; }
        //[ForeignKey("Cliente")]
        //public int ClienteId { get; set; }
        public EstadoTransitoEnum EstadoTransito { get; set; }
        public EstadoTransitoEnum EstadoTransitoCargaSuelta { get; set; }
    }
}
