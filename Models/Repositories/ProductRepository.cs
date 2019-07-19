using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models.Data;
using OnlineStore.Models.Interfaces; 

namespace OnlineStore.Models.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private OnlineStoreContext _context;
        public ProductRepository(OnlineStoreContext context) => _context = context;

        public IQueryable<Product> GetAll()
        {
            var products = _context.Product.Include(p => p.Category)
                                              .AsNoTracking()
                                              .AsQueryable();
            return products;
        }

        public async Task<IEnumerable<Product>> GetAllAsync(IQueryable<Product> products)
        { 
            return await products.ToListAsync();
        }

        public IQueryable<Product> GetListByFilter(Expression<Func<Product, bool>> filter)
        {
            return  _context.Product.Include(p => p.Category)
                                        .AsNoTracking()
                                        .AsQueryable()
                                        .Where(filter);
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Product.FindAsync(id);
        }
    }
}
