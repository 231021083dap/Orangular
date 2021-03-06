using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.DTO.Category.Requests
{
    public class NewCategory
    {
        // -----------------------------------------------------------------------------------------------------------------------
        [Required]
        [StringLength(255, ErrorMessage = "Max string length is 255")]
        [MinLength(1, ErrorMessage = "Min string length is 1")]
        public string categoryName { get; set; }
        // -----------------------------------------------------------------------------------------------------------------------
    }
}
