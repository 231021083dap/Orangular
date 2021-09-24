using OrangularAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.DTO.Login.Responses
{
    public class LoginResponse
    {
        public int id { get; set; }
        public string email { get; set; }
        public Role role { get; set; }
        public string token { get; set; }
    }
}
