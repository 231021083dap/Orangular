using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Orangular.DTO.Addresses.Requests
{
    public class UpdateAddress
    {
        // -----------------------------------------------------------------------------------------------------------------------
        [Required]
        [Range(1, int.MaxValue)]
        public int users_id { get; set; }
        // -----------------------------------------------------------------------------------------------------------------------
        [Required]
        [StringLength(255, ErrorMessage = "Max string length is 255")]
        [MinLength(1, ErrorMessage = "Min string length is 1")]
        public string address { get; set; }
        // -----------------------------------------------------------------------------------------------------------------------
        public int zip_code { get; set; }
        // -----------------------------------------------------------------------------------------------------------------------
        [StringLength(255, ErrorMessage = "Max string length is 255")]
        public string city_name { get; set; }
        // -----------------------------------------------------------------------------------------------------------------------
    }
}
