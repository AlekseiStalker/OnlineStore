using System;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models.Data;
using OnlineStore.Models.Interfaces;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using OnlineStore.Models.ViewModels;

namespace OnlineStore.Models.Repositories
{
    public class UserRepository : IUserRepository
    {
        private OnlineStoreContext _context;

        public UserRepository(OnlineStoreContext context) => _context = context;

        public async Task<IEnumerable<User>> GetAllAsync()// for test
        {
            return await _context.User.AsNoTracking().ToListAsync();
        }

        public async Task<User> GetByFilterAsync(Expression<Func<User, bool>> filter)
        { 
            return await _context.User.AsNoTracking().SingleOrDefaultAsync(filter);
        } 

        public async Task<bool> InsertAsync(User user)
        {
            await _context.User.AddAsync(user);
            return await _context.SaveChangesAsync() > 0;
        } 
         
        public async Task<bool> UpdateAsync(string userLogin, UserViewModel userViewModel)
        {
            User user = await _context.User.SingleOrDefaultAsync(u => u.Login == userLogin);
            user.Nickname = userViewModel.Nickname;
            user.Phone = userViewModel.Phone;

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
