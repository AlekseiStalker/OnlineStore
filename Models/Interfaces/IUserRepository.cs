using OnlineStore.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnlineStore.Models.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();//for debug purpuse
        Task<User> GetByFilterAsync(Expression<Func<User, bool>> filter);
        Task InsertAsync(User entity);
        Task UpdateAsync(User user); 
    }
}
