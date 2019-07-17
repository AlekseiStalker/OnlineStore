using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineStore.Models.Data;
using OnlineStore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        //delete
        public async Task<IEnumerable<PurchaseHistory>> GetAllAsync()
        {
            var purchaseHistory = _context.PurchaseHistory
                                        .Include(p => p.Product)
                                            .ThenInclude(c => c.Category)
                                        .Include(u => u.User);

            return await purchaseHistory.ToListAsync();
        }

        public async Task<IEnumerable<PurchaseHistory>> GetListByFilterAsync(string userLogin)
        {
            User user = await _context.User.SingleOrDefaultAsync(u => u.Login == userLogin);

            _logger.LogInformation("userID: " + user.Id, "");

            var purchaseHistory = _context.PurchaseHistory
                                            .Include(p => p.Product)
                                                .ThenInclude(c => c.Category)
                                            .Include(u => u.User)
                                            .Where(u => u.User.Id == user.Id);

            return await purchaseHistory.ToListAsync();
        }

        public async Task<bool> InsertAsync(string userLogin, Product product)
        {
            User user = await _context.User.Where(u => u.Login == userLogin).SingleAsync();  
            PurchaseHistory purchase = new PurchaseHistory() { UserId = user.Id, ProductId = product.Id };
             
            await _context.PurchaseHistory.AddAsync(purchase);
             
            return await _context.SaveChangesAsync() > 0;
        } 
    }
}
