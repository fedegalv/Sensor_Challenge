using Sensor_App.Models;
using System.Threading.Tasks;

namespace Sensor_App.Interfaces
{
    public interface ISegurosRepository : IGenericRepository<Seguro>
    {
       Task CleanSeguros(int UserId);
    }
}
