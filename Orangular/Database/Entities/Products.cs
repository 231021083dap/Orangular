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

            [Column(TypeName = "nvarchar(255)")]
            public string breed_name { get;  set; }

            [Range(1, int.MaxValue)]
            public int price { get; set; }

            [Range(1, int.MaxValue)]
            public float weight { get; set; }

            [Column(TypeName = "nvarchar(255)")]
             public string description { get; set; }

        // -----  ----- Muhmen //
    }
}
