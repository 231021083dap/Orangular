using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.DTO.Addresses.Responses
{
    public class AddressesResponse
    {
        public int addresses_id { get; set; }

        public string address { get; set; }

        public int zip_code { get; set; }

        public string city_name { get; set; }

        public AddressesUsersResponse Users { get; set; }


    }
}
