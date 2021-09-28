using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrangularAPI.Database.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set;}

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string BreedName { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Price { get; set; }

        [Required]
        public int Weight { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Gender { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Description { get; set; }

        [ForeignKey("Category.Id")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<OrderItem> OrderItem { get; set; } = new();
    }
}
