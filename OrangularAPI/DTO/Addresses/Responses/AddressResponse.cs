﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.DTO.Addresses.Responses
{
    public class AddressResponse
    {
        public int addressID { get; set; }

        public string address { get; set; }

        public int zipCode { get; set; }

        public string cityName { get; set; }

        public AddressUserResponse users { get; set; }
    }
}
