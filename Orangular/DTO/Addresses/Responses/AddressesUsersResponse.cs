using Orangular.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orangular.DTO.Addresses.Responses
{
    public class AddressesUsersResponse
    {
        public int users_id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public Role role { get; set; }

    }
}
