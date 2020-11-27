using Microsoft.EntityFrameworkCore;
using Sensor_App.DBContext;
using Sensor_App.Interfaces;
using Sensor_App.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sensor_App.Repository
{
    public class PermisoTipoRepository : GenericRepository<PermisoTipo>, IPermisoTipoRepository
    {
        public PermisoTipoRepository(SensorDbContext context) : base(context)
        {

        }
        public async Task AddParameterizedPermiso(string[] Permisos, int UserId)
        {
            try
            {
                foreach (var item in Permisos)
                {
                    PermisoTipo permiso = new PermisoTipo { Permiso = (Models.Enums.PermisosEnum)Int32.Parse(item), UserId = UserId };
                    _context.PermisoTipos.Add(permiso);
                    await _context.SaveChangesAsync();
                }

            }
            catch (System.Exception e)
            {

                throw e;
            }
        }

        public async Task CleanPermisos(int UserId)
        {
            try
            {
                var permisos = await _context.PermisoTipos.Where(p => p.UserId == UserId).ToListAsync();

                _context.PermisoTipos.RemoveRange(permisos);
                _context.SaveChanges();

            }
            catch (System.Exception e)
            {

                throw e;
            }
        }
    }
}
