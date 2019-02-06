using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly PieDbContext _pieDbContext;

        public PieRepository(PieDbContext pieDbContext)
        {
            _pieDbContext = pieDbContext;
        }

        public IEnumerable<Pie> Pies => _pieDbContext.Pies.Include(c => c.Category);

        public IEnumerable<Pie> PiesOfTheWeek => _pieDbContext.Pies.Include(p=>p.IsPieOfTheWeek).Where(p => p.IsPieOfTheWeek);

        public Pie GetPieById(int pieId) => _pieDbContext.Pies.FirstOrDefault(p => p.Id == pieId);
    }
}
