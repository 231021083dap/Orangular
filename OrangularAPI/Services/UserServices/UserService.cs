using OrangularAPI.Database.Entities;
using OrangularAPI.DTO.Login.Requests;
using OrangularAPI.DTO.Users.Responses;
using OrangularAPI.Helpers;
using OrangularAPI.Repositories.users;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.Services.UsersService
{
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
        private UserResponse userResponse(Users user) // userResponse bliver brugt til GetById, Create & Update
        {
            return user == null ? null : new UserResponse
            {
                userID = user.users_id,
                email = user.email,
                password = user.password,
                role = user.role
            };
        }
        public async Task<List<UserResponse>> GetAll()
        {
            List<Users> users = await _userRepository.GetAll();
            return users.Select(u => new UserResponse
            {
                userID = u.users_id,
                email = u.email,
                password = u.password, // Fjernes hvis password ikke skal vises.
                role = u.role,
                orderLists = u.order_lists.Select(o => new UserOrderListResponse
                {
                    orderListID = o.order_lists_id,
                    orderDateTime = o.order_date_time
                }).ToList(),
                addresses = u.addresses.Select(a => new UserAddressResponse
                {
                    addressID = a.addresses_id,
                    address = a.address,
                    zipCode = a.zip_code,
                    cityName = a.city_name
                }).ToList()
            }).ToList();
        }
        public async Task<UserResponse> GetById(int userId)
        {
            Users user = await _userRepository.GetById(userId);
            return userResponse(user);
        }
        public async Task<UserResponse> Create(NewUser newUser)
        {
            Users user = new Users
            {
                email = newUser.email,
                password = newUser.password,
                role = Role.User // All users created through Register has the role of user
            };
            user = await _userRepository.Create(user);
            return userResponse(user);
        }
        public async Task<UserResponse> Update(int userId, UpdateUser updateUser)
        {
            Users user = new Users
            {
                email = updateUser.email,
                password = updateUser.password,
                role = updateUser.role
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
