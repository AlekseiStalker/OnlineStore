using Microsoft.EntityFrameworkCore;
using OnlineStore.Models.Data;
using OnlineStore.Models.Interfaces;
using System;
using System.Collections.Generic;  
using System.Threading.Tasks;

namespace OnlineStore.Models.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private OnlineStoreContext _context;
        public PurchaseRepository(OnlineStoreContext context)  => _context = context; 

        public async Task<IEnumerable<PurchaseHistory>> GetAllAsync()
        {
            var purchaseHistory = _context.PurchaseHistory
                                        .Include(p => p.Product)
                                            .ThenInclude(c => c.Category)
                                        .Include(u => u.User);

            return await purchaseHistory.ToListAsync();
        }   

        public async Task InsertAsync(PurchaseHistory purchaseHistory)
        {
            await _context.PurchaseHistory.AddAsync(purchaseHistory);
            await _context.SaveChangesAsync();
        } 
    }
}
