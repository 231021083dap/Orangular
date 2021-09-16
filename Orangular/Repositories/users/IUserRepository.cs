using Orangular.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orangular.Repositories.users
{
    interface IUserRepository
    {
        // ----- Interface signature of user ----- Muhmen P.//
        Task<List<Users>> GetAll();
        Task<Users> GetById(int userId);
        Task<Users> Create(Users users);
        Task<Users> Update(int userId, Users users);
        Task<Users> Delete(int userId);
        // ----- Interface signature of user ----- Muhmen P.//
    }
}
