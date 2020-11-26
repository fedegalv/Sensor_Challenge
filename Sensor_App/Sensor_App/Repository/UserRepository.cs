using Microsoft.EntityFrameworkCore;
using Sensor_App.DBContext;
using Sensor_App.Interfaces;
using Sensor_App.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sensor_App.Repository
{
    public class UserRepository: GenericRepository<User>, IUserRepository
    {
        public UserRepository(SensorDbContext context):base(context)
        {

        }
        public async Task<User> AuthenticationAsync(string userName, string pass)
        {
            try
            {
                var u = await _entities.Where(x => x.NombreUsuario == userName && x.Contrasenia == pass).Include(user => user.Cliente).Include(user => user.Permisos).FirstOrDefaultAsync();
                return u;
            }
            catch (System.Exception e)
            {

                throw e;
            }
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            try
            {
                var u =  await _entities.Where(x => x.Id >= 0).Include(user => user.Cliente).Include(user => user.Permisos).ToListAsync();
                return u;
            }
            catch (System.Exception e)
            {

                throw e;
            }
        }
    }
}
