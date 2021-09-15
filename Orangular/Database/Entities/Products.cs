using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orangular.Database.Entities
{
    public class Products
    {

        // -----  ----- Muhmen //
        [Key]
        public int products_id {get; set;}

        [ForeignKey("Categories.categories_id")]
        public int categories_id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string breed_name { get;  set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int price { get; set; } // price angives i øre. 100kr = 10000 øre

        [Required]
        public int weight { get; set; } // weight unit is gram. 35kg = 35000

        public string gender { get; set; } // gender = male | female | null (reptil)

        [Column(TypeName = "nvarchar(255)")]
        public string description { get; set; }
        // -----  ----- Muhmen //
    }
}
