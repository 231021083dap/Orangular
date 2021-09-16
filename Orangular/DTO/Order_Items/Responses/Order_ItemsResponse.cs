using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orangular.DTO.Order_Items.Responses
{
    public class Order_ItemsResponse
    {
        public int order_items_id { get; set; }

        public int price { get; set; }
        
        public int quantity { get; set; }

        public Order_ItemsProductsResponse Products { get; set; }

        public Order_ItemsOrder_ListsResponse Order_Lists { get; set; }
    }
}
