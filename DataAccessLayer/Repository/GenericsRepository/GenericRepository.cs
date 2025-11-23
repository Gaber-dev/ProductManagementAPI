using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.GenericsRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetEntityById(int id)
        {
           return await _context.Set<T>().FindAsync(id);
        }

        public async Task AddEntity(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEntity(T entity)
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEntity(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
                throw new Exception("Entity not found");

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        





    }
}
