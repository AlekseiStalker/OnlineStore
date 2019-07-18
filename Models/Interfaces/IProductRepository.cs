using OnlineStore.Models.Data; 
using System.Collections.Generic; 
using System.Threading.Tasks;

namespace OnlineStore.Models.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync(); 
    }
}
