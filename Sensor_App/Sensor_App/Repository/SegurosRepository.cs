using Microsoft.EntityFrameworkCore;
using Sensor_App.DBContext;
using Sensor_App.Interfaces;
using Sensor_App.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Sensor_App.Repository
{
    public class SegurosRepository :GenericRepository<Seguro>, ISegurosRepository
    {
        public SegurosRepository(SensorDbContext context) : base(context)
        {
            
        }
        public async Task CleanSeguros(int UserId)
        {
            try
            {
                var seguros = await _context.Seguros.Where(p => p.ClienteId == UserId).ToListAsync();

                _context.Seguros.RemoveRange(seguros);
                _context.SaveChanges();

            }
            catch (System.Exception e)
            {

                throw e;
            }
        }
    }
}
