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
        Task<List<Users>> getAll();
        Task<Users> getById(int userId);
        Task<Users> create(Users users);
        Task<Users> update(int userId, Users users);
        Task<Users> delete(int userId);
        // ----- Interface signature of user ----- Muhmen P.//
    }
}
