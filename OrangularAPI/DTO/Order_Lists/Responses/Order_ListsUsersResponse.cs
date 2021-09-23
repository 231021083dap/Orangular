using Orangular.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.DTO.Order_Lists.Responses
{
    public class Order_ListsUsersResponse
    {
        public int users_id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public Role role { get; set; }
    }
}
