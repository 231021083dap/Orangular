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
        [Key]
        public int products_id {get; set;}

        public int animal_id { get; set; }

        [Column(TypeName = "nvarchar(32)")]
        public string breed_name { get;  set; }
        
    }
}
