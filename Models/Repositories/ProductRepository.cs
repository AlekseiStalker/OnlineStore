using Microsoft.EntityFrameworkCore;
using OnlineStore.Models.Data;
using OnlineStore.Models.Interfaces; 
using System.Collections.Generic; 
using System.Threading.Tasks;

namespace OnlineStore.Models.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private OnlineStoreContext _context;
        public ProductRepository(OnlineStoreContext context) => _context = context;
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = _context.Product.Include(p => p.Category);
            return await products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Product.FindAsync(id);
        }
    }
}
