using Menuu.Context;
using Menuu.Models;
using Menuu.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Menuu.Repositories.Interfaces
{
    public class SnackRepository : ISnackRepository
    {
        private readonly AppDbContext _context;
        public SnackRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Snack> Snacks => _context.Snacks.Include(c => c.Category);
        public IEnumerable<Snack> FavoriteSnacks => _context.Snacks.Where(s=> s.IsFavorite).Include(c => c.Category);
        public Snack GetSnackById(int snackId)
        {
            return _context.Snacks.FirstOrDefault(s => s.SnackId == snackId);
        }
    }
}
