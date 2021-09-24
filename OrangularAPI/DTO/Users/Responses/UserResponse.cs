using OrangularAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.DTO.Users.Responses
{
    public class UserResponse
    {
        public int userID { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public Role role { get; set; }

        public List<UserOrderListResponse> orderLists { get; set; } = new();

        public List<UserAddressResponse> addresses { get; set; } = new();


    }
}
