using Sensor_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sensor_App.Interfaces
{
    public interface IClienteRepository : IGenericRepository<Cliente>
    {
        Task<Cliente> GetClienteByIdAsync(int id);
        Task<List<Cliente>> GetAllClientesAsync();
    }
}
