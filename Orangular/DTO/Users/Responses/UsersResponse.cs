using Orangular.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orangular.DTO.Users.Responses
{
    public class UsersResponse
    {
        public int users_id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public Role role { get; set; }

        public List<UsersOrder_ListsResponse> Order_Lists { get; set; }

        public List<UsersAddressesResponse> Addresses { get; set; }


    }
}
