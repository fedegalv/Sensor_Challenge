using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sensor_App.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IClienteRepository ClienteRepository { get; }

        IPermisoTipoRepository PermisoTipoRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();

    }
}
