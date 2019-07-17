using System;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models.Data;
using OnlineStore.Models.Interfaces;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace OnlineStore.Models.Repositories
{
    public class UserRepository : IUserRepository
    {
        private OnlineStoreContext _context;

        public UserRepository(OnlineStoreContext context) => _context = context;

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.User.ToListAsync();
        }
        public async Task<User> GetById(int id)
        {
            return await _context.User.FindAsync(id);
        }

        public async Task<User> GetByFilterAsync(Expression<Func<User, bool>> filter)
        { 
            return await _context.User.SingleOrDefaultAsync(filter);
        } 

        public async Task InsertAsync(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
        } 
         
        public async Task UpdateAsync(User user)
        {
            User u = await GetById(user.Id);
            u.Login = user.Login;
            u.Password = user.Password;
            u.Nickname = user.Nickname;
            u.Phone = user.Phone;

            await _context.SaveChangesAsync();
        }
    }
}
