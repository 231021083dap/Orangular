using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OrangularAPI.Database.Entities
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }



        [Required]
        public int Price { get; set; }



        [Required]
        public int Quantity { get; set; }



        [Required]
        [ForeignKey("OrderList.Id")]
        public int OrderListIdxxx { get; set; }
        public OrderList OrderList { get; set; }



        [Required]
        [ForeignKey("Product.Id")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
