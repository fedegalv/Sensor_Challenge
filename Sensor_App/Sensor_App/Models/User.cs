using Sensor_App.Models.Enums;
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
        public User()
        {
            //Cliente = new Cliente();
            //Permisos = new Permisos();
            //Permisos = new HashSet<PermisosEnum>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage ="Este campo es requerido")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(30)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(20)]
        [Display(Name = "Nombre Usuario")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(100)]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Contrasenia { get; set; }

        public virtual ICollection<PermisoTipo> Permisos { get; set; }
        //[Key]
        //public int IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }

        //[ForeignKey("ClienteID")]
        //public Cliente Cliente {get;set;}
        //public int ClienteID { get; set; }

        //[ForeignKey("PermisosID")]
        //[Required]
        //public Permisos Permisos {get;set;}
        //public int PermisosID { get; set; }
    }
}
