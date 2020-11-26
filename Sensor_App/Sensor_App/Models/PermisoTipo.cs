using Sensor_App.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sensor_App.Models
{
    public class PermisoTipo
    {
        public int Id { get; set; }
        public PermisosEnum Permiso { get; set; }
        //[ForeignKey("User")]
        public int UserId { get; set; }
        //public int ListadoUsuarios { get { return (int)PermisosEnum.Listado_Usuario; } set { this.ListadoUsuarios = value; } }
        //public int ModificacionUsuario { get { return (int)PermisosEnum.Modificacion_Usuario; } set { this.ModificacionUsuario = value; } }
        //public int BajaUsuario { get { return (int)PermisosEnum.Baja_Usuario; } set { this.BajaUsuario = value; } }
        //public int ListadoClientes { get { return (int)PermisosEnum.Listado_Cliente; } set { this.ListadoClientes = value; } }
        //public int AltaCliente { get { return (int)PermisosEnum.Alta_Cliente; } set { this.AltaCliente = value; } }
        //public int ModificacionCliente { get { return (int)PermisosEnum.Listado_Cliente; } set { this.ModificacionCliente = value; } }
        //public int BajaCliente { get { return (int)PermisosEnum.Baja_Cliente; } set { this.BajaCliente = value; } }
        //public int VisualizacionMapa { get { return (int)PermisosEnum.Visualizacion_Mapa; } set { this.VisualizacionMapa = value; } }
    }
}
