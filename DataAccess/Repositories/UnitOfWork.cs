using DataAccess.Contexts;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        private readonly CompetetionDbContext dbContext;        
        public IPlayerRepository Players { get; set; }
        public UnitOfWork(CompetetionDbContext dbContext)
        {
            this.dbContext = dbContext;
            Players = new PlayerRepository(dbContext);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);            
        }
        public async ValueTask<int> Commit()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}
