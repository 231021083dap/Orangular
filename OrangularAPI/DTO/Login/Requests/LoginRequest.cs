using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.DTO.Login.Requests
{
    public class LoginRequest
    {
        [Required]
        [StringLength(255, ErrorMessage = "Email must be 255 or less chars")]
        public string Email { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Password must be 255 or less chars")]
        public string Password { get; set; }
    }
}
