using Orangular.Authorization;
using Orangular.Database.Entities;
using OrangularAPI.DTO.Login.Requests;
using OrangularAPI.DTO.Login.Responses;
using OrangularAPI.DTO.Users.Responses;
using Orangular.Repositories.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orangular.Services.users
{

    public interface IUserService
    {
       // Task<LoginResponse> Authenticate(LoginRequest login);
        Task<List<UsersResponse>> GetAll();
        Task<UsersResponse> GetById(int userId);
        Task<UsersResponse> Create(NewUser newUser);
        Task<UsersResponse> Update(int userId, UpdateUser updateUser);
        Task<bool> Delete(int userId);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
       // private readonly IJwtUtils _jwtUtils;
        public UserService(IUserRepository userRepository/*, IJwtUtils jwtUtils*/)
        {
            _userRepository = userRepository;
         //   _jwtUtils = jwtUtils;
        }
        //public async Task<LoginResponse> Authenticate(LoginRequest login)
        //{
        //    Users user = await _userRepository.GetByEmail(login.Email);
        //    if (user == null) return null;
        //    if (user.password == login.Password)
        //    {
        //        LoginResponse response = new LoginResponse
        //        {
        //            Id = user.users_id,
        //            Email = user.email,
        //            Role = user.role,
        //            Token = _jwtUtils.GenerateJwtToken(user)
        //        };
        //        return response;
        //    }
        //    return null;
        //}
        private UsersResponse userResponse(Users user) // userResponse bliver brugt til GetById, Create & Update
        {
            return user == null ? null : new UsersResponse
            {
                users_id = user.users_id,
                email = user.email,
                password = user.password,
                role = user.role
            };
        }
        public async Task<List<UsersResponse>> GetAll()
        {
            List<Users> users = await _userRepository.GetAll();
            return users.Select(u => new UsersResponse
            {
                users_id = u.users_id,
                email = u.email,
                password = u.password, // Fjernes hvis password ikke skal vises.
                role = u.role,
                Order_Lists = u.order_lists.Select(o => new UsersOrder_ListsResponse
                {
                    order_lists_id = o.order_lists_id,
                    order_date_time = o.order_date_time
                }).ToList(),
                Addresses = u.addresses.Select(a => new UsersAddressesResponse
                {
                    addresses_id = a.addresses_id,
                    address = a.address,
                    zip_code = a.zip_code,
                    city_name = a.city_name
                }).ToList()
            }).ToList();
        }
        public async Task<UsersResponse> GetById(int userId)
        {
            Users user = await _userRepository.GetById(userId);
            return userResponse(user);
        }
        public async Task<UsersResponse> Create(NewUser newUser)
        {
            Users user = new Users
            {
                email = newUser.Email,
                password = newUser.Password,
                role = Helpers.Role.User // All users created through Register has the role of user
            };
            user = await _userRepository.Create(user);
            return userResponse(user);
        }
        public async Task<UsersResponse> Update(int userId, UpdateUser updateUser)
        {
            Users user = new Users
            {
                email = updateUser.Email,
                password = updateUser.Password,
                role = updateUser.Role
            };
            user = await _userRepository.Update(userId, user);
            return userResponse(user);
        }
        public async Task<bool> Delete(int userId)
        {
            var result = await _userRepository.Delete(userId);
            if (result != null) return true;
            else return false;
        }
    }
}
