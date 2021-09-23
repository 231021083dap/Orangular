using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.DTO.Addresses.Responses
{
    public class AddressResponse
    {
        public int addressID { get; set; }

        public string Address { get; set; }

        public int zipCode { get; set; }

        public string cityName { get; set; }

        public AddressUserResponse user { get; set; }
    }
}
