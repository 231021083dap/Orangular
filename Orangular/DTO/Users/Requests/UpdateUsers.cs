using Orangular.API.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Orangular.DTO.Users.Requests
{
    public class UpdateUsers
    {
        // -----------------------------------------------------------------------------------------------------------------------
        [Required]
        [StringLength(255, ErrorMessage = "Max string length is 255")]
        [MinLength(1, ErrorMessage = "Min string length is 1")]
        public string email { get; set; }
        // -----------------------------------------------------------------------------------------------------------------------
        [Required]
        [StringLength(255, ErrorMessage = "Max string length is 255")]
        [MinLength(1, ErrorMessage = "Min string length is 1")]
        public string password { get; set; }
        // -----------------------------------------------------------------------------------------------------------------------
        [Required]
        public Role role { get; set; }
        // -----------------------------------------------------------------------------------------------------------------------

    }
}
