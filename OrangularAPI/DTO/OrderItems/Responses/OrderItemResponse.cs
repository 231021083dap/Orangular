using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.DTO.OrderItems.Responses
{
    public class OrderItemResponse
    {
        public int OrderItemID { get; set; }

        public int Price { get; set; }
        
        public int Quantity { get; set; }

        public OrderItemProductResponse Product { get; set; }

        public OrderItem_OrderListResponse Order { get; set; }
    }
}
