using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Orangular.DTO.Products.Requests
{
    public class UpdateProducts
    {
        // -----------------------------------------------------------------------------------------------------------------------
        [Required]
        [Range(1, int.MaxValue)]
        public int categories_id { get; set; }
        // -----------------------------------------------------------------------------------------------------------------------
        [Required]
        [StringLength(255, ErrorMessage = "Max string length is 255")]
        [MinLength(1, ErrorMessage = "Min string length is 1")]
        public string breed_name { get; set; }
        // -----------------------------------------------------------------------------------------------------------------------
        [Required]
        [Range(1, int.MaxValue)]
        public int price { get; set; }
        // -----------------------------------------------------------------------------------------------------------------------
        [Required]
        [Range(1, float.MaxValue)]
        public float weight { get; set; }
        // -----------------------------------------------------------------------------------------------------------------------
        [StringLength(255, ErrorMessage = "Max string length is 255")]
        [MinLength(1, ErrorMessage = "Min string length is 1")]
        public string description { get; set; }
    }
}
