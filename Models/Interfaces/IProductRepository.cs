using System;
using OnlineStore.Models.Data;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;

namespace OnlineStore.Models.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        IQueryable<Product> GetAll();
        Task<IEnumerable<Product>> GetAllAsync(IQueryable<Product> products);
        IQueryable<Product> GetListByFilter(Expression<Func<Product, bool>> filter);
    }
}
