using Sensor_App.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sensor_App.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string RazonSocial { get; set; }

        [Required]
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
        public int CodPostal { get; set; }

        [Required]
        public Zona Zona { get; set; }

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

        [Required]
        public Seguro Seguro { get; set; }

        [Required]
        [StringLength(30)]
        public bool Activo { get; set; }
    }
}
