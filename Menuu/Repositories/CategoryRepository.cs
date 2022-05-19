using Menuu.Context;
using Menuu.Models;
using Menuu.Repositories.Interfaces;

namespace Menuu.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> Categories => _context.Categories;

    }
}
