using Orangular.Authorization;
using Orangular.Database.Entities;
using Orangular.DTO.Login.Requests;
using Orangular.DTO.Login.Responses;
using Orangular.DTO.Users.Responses;
using Orangular.Repositories.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orangular.Services.users
{

    public interface IUserService
    {
        Task<List<UsersResponse>> GetAll();
        Task<UsersResponse> GetById(int userId);
        //Task<LoginResponse> Authenticate(LoginRequest login);
        //Task<UsersResponse> Register(RegisterUser newUser);
        //Task<UsersResponse> Update(int userId, UpdateUser updateUser);

        // delete
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
       // private readonly IJwtUtils _jwtUtils;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
           // _jwtUtils = jwtUtils;
        }
        public async Task<List<UsersResponse>> GetAll()
        {
            List<Users> users = await _userRepository.GetAll();
            return users == null ? null : users.Select(u => new UsersResponse
            {
                users_id = u.users_id,
                email = u.email,
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
            return null;
        }
    }
}
