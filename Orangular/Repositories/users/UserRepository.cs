using Microsoft.EntityFrameworkCore;
using Orangular.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orangular.Repositories.users
{
    public class UserRepository 
    {
        interface IUserRepository
        {
            Task<List<Users>> GetAll();
            Task<Users> GetById(int userId);
            Task<Users> Create(Users user);
            Task<Users> Update(int userId, Users user);
            Task<Users> Delete(int userId);
        }

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
        public async Task<Users> GetById(int userId) // Mangler check hvis id ikke findes
        {
            return await _context.Users
                .Include(a => a.addresses)
                .Include(b => b.order_lists)
                .FirstOrDefaultAsync(u => u.users_id == userId);
        }
        public async Task<Users> Create(Users user)
        {
            if (_context.Users.Any(u => u.users_id == user.users_id)) throw new Exception("Nice try, userId " + user.users_id + " already Exists");
            else if (_context.Users.Any(u => u.email == user.email)) throw new Exception("Email " + user.email + " is already taken");
            else if (user.password == null) throw new Exception("You must enter a password");
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<Users> Update(int userId, Users user)
        {
            Users updateUser = await _context.Users.FirstOrDefaultAsync(u => u.users_id == userId);
            if (updateUser != null)
            {
                if (_context.Users.Any(u => u.users_id != userId && u.email == user.email)) throw new Exception("Email " + user.email + " is already taken");
                updateUser.email = user.email;
                if (user.password != null) updateUser.password = user.password;
                updateUser.role = user.role;
            }
            return updateUser;
        }
        public async Task<Users> Delete(int userId)
        {
            Users deleteUser = await _context.Users.FirstOrDefaultAsync(u => u.users_id == userId);
            if (deleteUser != null)
            {
                _context.Users.Remove(deleteUser);
                await _context.SaveChangesAsync();
            }
            return deleteUser;
        }
    }
}
