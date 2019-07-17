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

        public async Task<bool> InsertAsync(User user)
        {
            await _context.User.AddAsync(user);
            return await _context.SaveChangesAsync() > 0;
        } 
         
        public async Task<bool> UpdateAsync(User user)
        {
            User u = await GetById(user.Id); //may be should find by Login in User.Identity.NAme
            u.Nickname = user.Nickname;
            u.Phone = user.Phone;

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
