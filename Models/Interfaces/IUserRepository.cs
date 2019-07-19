using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OnlineStore.Models.Data;
using OnlineStore.Models.ViewModels;

namespace OnlineStore.Models.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();//for test
        Task<User> GetByFilterAsync(Expression<Func<User, bool>> filter);
        Task<bool> InsertAsync(User user);
        Task<bool> UpdateAsync(string userLogin, UserViewModel user); 
    }
}
