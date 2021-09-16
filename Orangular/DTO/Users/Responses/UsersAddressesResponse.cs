using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orangular.DTO.Users.Responses
{
    public class UsersAddressesResponse
    {
        public int addresses_id { get; set; }

        public string address { get; set; }

        public int zip_code { get; set; }

        public string city_name { get; set; }

    }
}
