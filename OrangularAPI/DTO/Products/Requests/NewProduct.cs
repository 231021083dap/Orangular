using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.DTO.Products.Requests
{
    public class NewProduct
    {
        // -----------------------------------------------------------------------------------------------------------------------
        [Required]
        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }
        // -----------------------------------------------------------------------------------------------------------------------
        [Required]
        [StringLength(255, ErrorMessage = "Max string length is 255")]
        [MinLength(1, ErrorMessage = "Min string length is 1")]
        public string BreedName { get; set; }
        // -----------------------------------------------------------------------------------------------------------------------
        [Required]
        [Range(1, int.MaxValue)]
        public int Price { get; set; }
        // -----------------------------------------------------------------------------------------------------------------------
        [Required]
        [Range(1, int.MaxValue)]
        public int Weight { get; set; }
        // -----------------------------------------------------------------------------------------------------------------------
        [StringLength(255, ErrorMessage = "Max string length is 255")]
        public string Gender { get; set; }
        // -----------------------------------------------------------------------------------------------------------------------
        [StringLength(255, ErrorMessage = "Max string length is 255")]
        public string Description { get; set; }

    }
}
