using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orangular.Database.Entities
{
    public class Categories
    {
        [Key]
        public int categories_id { get; set;  }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string category_name { get; set; }
    }
}
