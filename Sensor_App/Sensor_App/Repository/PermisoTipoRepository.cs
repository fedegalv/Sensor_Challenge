using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Sensor_App.DBContext;
using Sensor_App.Interfaces;
using Sensor_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sensor_App.Repository
{
    public class PermisoTipoRepository : GenericRepository<PermisoTipo>, IPermisoTipoRepository
    {
        public PermisoTipoRepository(SensorDbContext context) : base(context)
        {

        }
        public void AddParameterizedPermiso(string[] Permisos, int UserId)
        {
            try
            {
                foreach (var item in Permisos)
                {
                    PermisoTipo permiso = new PermisoTipo { Permiso = (Models.Enums.PermisosEnum)Int32.Parse(item), UserId = UserId };
                    _context.PermisoTipos.Add(permiso);
                    _context.SaveChangesAsync();
                }

            }
            catch (System.Exception e)
            {

                throw e;
            }
        }
    }
}
