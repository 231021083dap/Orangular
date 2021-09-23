using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.DTO.OrderLists.Responses
{
    public class OrderList_OrderItemResponse
    {

        public int order_items_id { get; set; }
        public string product_name { get; set; } // I stedet for at bruge products_id, anbefaler Jack at bruge et navn
        public int price { get; set; }
        public int quantity { get; set; }

    }
}
