using Microsoft.EntityFrameworkCore;
using Orangular.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orangular.Repositories.users
{
    public class UserRepository : IUserRepository
    {

        private readonly OrangularProjectContext _context;
        public UserRepository(OrangularProjectContext Context)
        {
            _context = Context;
        }
        public async Task<List<Users>> GetAll()
        {
            return await _context.Users
                .Include(a => a.addresses)
                .Include(b => b.order_lists)
                .ToListAsync();
        }
        public async Task<Users> GetById(int userId)
        {
            return await _context.Users
                .Include(a => a.addresses)
                .Include(b => b.order_lists)
                .FirstOrDefaultAsync(u => u.users_id == userId);
        }
        public async Task<Users> Create(Users users)
        {
                 
        }
        public async Task<Users> Update(int userId, Users users)
        {
            
        }
        public async Task<Users> Delete(int userId)
        {
            
        }
    }
}
