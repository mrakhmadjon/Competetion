using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    public class CompetetionDbContext : DbContext
    {
        public CompetetionDbContext(DbContextOptions<CompetetionDbContext> options)
            : base(options)
        {          
        }

        public DbSet<Player> Players { get; set; }

    }
}
