using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.DTO.Addresses.Requests
{
    public class NewAddress
    {
        // -----------------------------------------------------------------------------------------------------------------------
        [Required]
        [Range(1, int.MaxValue)]
        public int userID { get; set; }
        // -----------------------------------------------------------------------------------------------------------------------
        [Required]
        [StringLength(255, ErrorMessage = "Max string length is 255")]
        [MinLength(1, ErrorMessage = "Min string length is 1")]
        public string address { get; set; }
        // -----------------------------------------------------------------------------------------------------------------------
        //[StringLength(255, ErrorMessage = "Max string length is 255")]
        public int zipCode { get; set; }
        // -----------------------------------------------------------------------------------------------------------------------
        [StringLength(255, ErrorMessage = "Max string length is 255")]
        public string cityName { get; set; }
        // -----------------------------------------------------------------------------------------------------------------------
    }
}
