using Sensor_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sensor_App.Interfaces
{
    public interface IPermisoTipoRepository : IGenericRepository<PermisoTipo>
    {
        Task AddParameterizedPermiso(string[] Permisos, int UserId);
        Task CleanPermisos(int UserId);
    }
}
