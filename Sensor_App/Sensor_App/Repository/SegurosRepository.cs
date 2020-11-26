using Sensor_App.DBContext;
using Sensor_App.Interfaces;
using Sensor_App.Models;

namespace Sensor_App.Repository
{
    public class SegurosRepository :GenericRepository<Seguro>, ISegurosRepository
    {
        public SegurosRepository(SensorDbContext context) : base(context)
        {

        }
    }
}
