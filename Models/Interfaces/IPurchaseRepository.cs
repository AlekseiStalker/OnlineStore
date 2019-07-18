using OnlineStore.Models.Data;
using System;
using System.Collections.Generic; 
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnlineStore.Models.Interfaces
{
    public interface IPurchaseRepository
    { 
        Task<IEnumerable<PurchaseHistory>> GetListByFilterAsync(string userLogin);
        Task<bool> InsertAsync(string userLogin, int productId); 
    }
}
