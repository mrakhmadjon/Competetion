using DataAccess.Contexts;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
#pragma warning disable
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly CompetetionDbContext dbContext;
        private readonly DbSet<T> dbSet;

        public GenericRepository(CompetetionDbContext dbContext)
        {
            this.dbContext = dbContext;    
            this.dbSet = dbContext.Set<T>();
        }


        public async ValueTask<T> AddAsync(T entity)
        {
           await dbSet.AddAsync(entity);
           return entity;
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var entity = await dbSet.FindAsync(id);
            if(entity != null)
            {
                dbSet.Remove(entity);
                return true;
            }                       
           return false;
        }

        public async ValueTask<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async ValueTask<T> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async ValueTask<T> UpdateAsync(T entity)
        {
            var entry = dbSet.Update(entity);

            return entry.Entity;          
            
        }
    }
}
