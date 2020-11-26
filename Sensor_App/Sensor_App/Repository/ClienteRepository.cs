using Microsoft.EntityFrameworkCore;
using Sensor_App.DBContext;
using Sensor_App.Interfaces;
using Sensor_App.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Sensor_App.Repository
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(SensorDbContext context) : base(context)
        {

        }
        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            try
            {
                var u = await _entities.Where(x => x.ClienteId == id).Include(cliente => cliente.Seguro).FirstOrDefaultAsync();
                return u;
            }
            catch (System.Exception e)
            {

                throw e;
            }
        }
    }
}
