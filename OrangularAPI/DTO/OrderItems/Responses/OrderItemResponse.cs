using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.DTO.OrderItems.Responses
{
    public class OrderItemResponse
    {
        public int orderItemsID { get; set; }

        public int price { get; set; }
        
        public int quantity { get; set; }

        public Order_ItemsProductsResponse Product { get; set; }

        public Order_ItemsOrder_ListsResponse OrderList { get; set; }
    }
}
