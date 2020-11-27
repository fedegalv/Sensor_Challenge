using Sensor_App.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sensor_App.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> AuthenticationAsync(string userName, string pass);
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
    }
}
