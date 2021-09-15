using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Orangular.Database.Entities
{
    public class Order_Items
    {
        [Key]
        public int order_items_id { get; set; }

        [Required]
        [ForeignKey("Products.products_id")]
        public int products_id { get; set; }

        [Required]
        public int price { get; set; }

        [Required]
        public int quantity { get; set; }
    }
}
