using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sensor_App.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(int id);
        Task<T> GetByLongId(long id);
        Task Add(T entity);
        void Update(T entity);
        Task Delete(int id);
        Task DeleteLong(long id);
        Task<List<T>> GetAllAsync();
    }
}
