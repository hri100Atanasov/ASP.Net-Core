using Angular.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular.Persistence
{
    public class AutomobileDbContext : DbContext
    {
        public AutomobileDbContext(DbContextOptions<AutomobileDbContext> options)
            :base(options)
        {
        }

        public DbSet<Make> Makes { get; set; }
    }
}
