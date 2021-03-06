using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        ValueTask<T> GetByIdAsync(int id);
        ValueTask<IEnumerable<T>> GetAllAsync();
        ValueTask<T> AddAsync(T entity);
        ValueTask<T> UpdateAsync(T entity);
        ValueTask<bool> DeleteAsync(int id);
    }
}
