using Sensor_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sensor_App.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> AuthenticationAsync(string userName, string pass);
        Task<List<User>> GetAllUsersAsync();
    }
}
