using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineStore.Models.Data;
using OnlineStore.Models.Interfaces;

namespace OnlineStore.Models.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private OnlineStoreContext _context;

        private readonly ILogger _logger;
        public PurchaseRepository(OnlineStoreContext context, ILogger<PurchaseRepository> logger)
        {
            _context = context;
            _logger = logger;
        }  

        public async Task<IEnumerable<PurchaseHistory>> GetListByFilterAsync(string userLogin)
        {
            User user = await _context.User.AsNoTracking().SingleOrDefaultAsync(u => u.Login == userLogin);
             
            var purchaseHistory = _context.PurchaseHistory.AsNoTracking()
                                            .Include(p => p.Product)
                                                .ThenInclude(c => c.Category)
                                            .Include(u => u.User)
                                            .Where(u => u.User.Id == user.Id);

            return await purchaseHistory.ToListAsync();
        }

        public async Task<bool> InsertAsync(string userLogin, int productId)
        {
            User user = await _context.User.AsNoTracking()
                                        .Where(u => u.Login == userLogin)
                                        .SingleAsync();  
            PurchaseHistory purchase = new PurchaseHistory() { UserId = user.Id, ProductId = productId };
             
            await _context.PurchaseHistory.AddAsync(purchase);
             
            return await _context.SaveChangesAsync() > 0;
        } 
    }
}
