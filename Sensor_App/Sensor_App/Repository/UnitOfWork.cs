using Sensor_App.DBContext;
using Sensor_App.Interfaces;
using System.Threading.Tasks;

namespace Sensor_App.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly SensorDbContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IPermisoTipoRepository _permisoTipoRepository;
        private readonly ISegurosRepository _seguroRepository;
        public UnitOfWork(SensorDbContext context)
        {
            _context = context;
        }
        public IUserRepository UserRepository => _userRepository ?? new UserRepository(_context);
        public IClienteRepository ClienteRepository => _clienteRepository ?? new ClienteRepository(_context);
        public IPermisoTipoRepository PermisoTipoRepository => _permisoTipoRepository ?? new PermisoTipoRepository(_context);
        public ISegurosRepository SeguroRepository => _seguroRepository ?? new SegurosRepository(_context);

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
