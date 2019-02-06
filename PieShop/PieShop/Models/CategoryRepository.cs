using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PieDbContext _pieDbContext;
        public CategoryRepository(PieDbContext pieDbContext)
        {
            _pieDbContext = pieDbContext;
        }

        public IEnumerable<Category> Categories => _pieDbContext.Categories;
    }
}
