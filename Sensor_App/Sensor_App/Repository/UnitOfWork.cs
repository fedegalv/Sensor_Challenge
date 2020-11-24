using Sensor_App.DBContext;
using Sensor_App.Interfaces;
using System.Threading.Tasks;

namespace Sensor_App.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SensorDbContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IClienteRepository _clienteRepository;
        public UnitOfWork(SensorDbContext context)
        {
            _context = context;
        }
        public IUserRepository UserRepository => _userRepository ?? new UserRepository(_context);
        public IClienteRepository ClienteRepository => _clienteRepository ?? new ClienteRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
