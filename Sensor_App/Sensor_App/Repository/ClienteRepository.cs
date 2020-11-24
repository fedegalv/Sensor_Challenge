using Sensor_App.DBContext;
using Sensor_App.Interfaces;
using Sensor_App.Models;

namespace Sensor_App.Repository
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(SensorDbContext context) : base(context)
        {

        }
    }
}
