using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sensor_App.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(20)]
        public string NombreUsuario { get; set; }

        [Required]
        [StringLength(100)]
        public string Contrasenia { get; set; }

        [ForeignKey("ClienteID")]
        public Cliente Cliente { get; set; }

        [Required]
        public Permisos Permisos { get; set; }
    }
}
