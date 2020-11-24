using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sensor_App.Models
{
    public class LoginUserModel
    {
        [Display(Name = "Credenciales usuario")]
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        public string Usuario { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Este campo es obligatorio!")]

        [DataType(DataType.Password)]
        public string Contrasenia { get; set; }
    }
}
