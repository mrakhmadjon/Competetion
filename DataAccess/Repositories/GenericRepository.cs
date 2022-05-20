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

        public ValueTask DeleteAsync(T entity)
        {
            dbSet.Remove(entity);            
            return ValueTask.CompletedTask;
        }

        public async ValueTask<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async ValueTask<T> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public ValueTask UpdateAsync(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;            
            return ValueTask.CompletedTask;
        }
    }
}
