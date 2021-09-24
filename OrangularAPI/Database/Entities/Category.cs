using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrangularAPI.Database.Entities
{

    public class Category
    {
        [Key]
        public int Id { get; set;  }



        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string CategoryName { get; set; }
        public List<Product> Product { get; set; } = new();
    }
}
