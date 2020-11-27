using System;
using System.Threading.Tasks;

namespace Sensor_App.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IClienteRepository ClienteRepository { get; }
        IPermisoTipoRepository PermisoTipoRepository { get; }
        ISegurosRepository SeguroRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();

    }
}
