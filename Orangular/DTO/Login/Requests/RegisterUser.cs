using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Orangular.DTO.Login.Requests
{
    public class RegisterUser
    {
        [Required]
        [StringLength(255, ErrorMessage = "Email must be less than 255 chars")]
        public string Email { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Password must be less than 255 chars")]
        public string Password { get; set; }
    }
}
