using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sensor_App.Models.ViewModel
{
    public class UserViewModel
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
        [Display(Name = "Nobre Usuario")]
        public string NombreUsuario { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Contraseña")]
        public string Contrasenia { get; set; }

        public virtual ICollection<PermisoTipo> Permisos { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
