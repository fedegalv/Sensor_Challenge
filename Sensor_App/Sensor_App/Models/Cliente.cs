using Sensor_App.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sensor_App.Models
{
    public class Cliente
    {
        public Cliente()
        {
            Seguro = new HashSet<Seguro>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int ClienteId { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Razon social")]
        public string RazonSocial { get; set; }

        [Required]
        [Display(Name = "Nro sucursal")]
        public int NroSucursal { get; set; }

        [Required]
        [StringLength(30)]
        public string Direccion { get; set; }

        [Required]
        [StringLength(30)]
        public string Pais { get; set; }

        [Required]
        [StringLength(30)]
        public string Ciudad { get; set; }

        [Required]
        [Display(Name = "Codigo postal")]
        public int CodPostal { get; set; }

        [Required]
        public ZonaEnum Zona { get; set; }

        [Required]
        [StringLength(30)]
        public string Telefono { get; set; }

        [Required]
        [StringLength(30)]
        public string Fax { get; set; }

        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        [Required]
        [StringLength(30)]
        public string Web { get; set; }

        public ICollection<Seguro> Seguro { get; set; }
        //[ForeignKey("SeguroID")]
        //public Seguro Seguro { get; set; }
        //[Key]
        //public int IdSeguro { get; set; }
        //public virtual Seguro Seguro { get; set; }
        //public int ClienteID { get; set; }

        [Required]
        [StringLength(30)]
        public bool Activo { get; set; }
    }
}
