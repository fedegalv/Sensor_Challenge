using Sensor_App.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sensor_App.Models
{
    public class Seguro
    {
        public int Id { get; set; }
        //[ForeignKey("Cliente")]
       public int ClienteId { get; set; }
        [Display(Name = "Uruguay - Transitos")]
        public EstadoTransitoEnum Uruguay_Transitos { get; set; }
        [Display(Name = "Uruguay - Transitos carga suelta")]
        public EstadoTransitoEnum Uruguay_Transitos_Carga_Suelta { get; set; }
    }
}
