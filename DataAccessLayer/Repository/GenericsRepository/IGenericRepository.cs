using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.GenericsRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetEntityById(int id);

        Task AddEntity(T entity);

        Task UpdateEntity(T entity);

        Task DeleteEntity(int id);
    }
}
