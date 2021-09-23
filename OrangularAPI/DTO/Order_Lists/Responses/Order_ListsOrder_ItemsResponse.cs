using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.DTO.Order_Lists.Responses
{
    public class Order_ListsOrder_ItemsResponse
    {

        public int order_items_id { get; set; }
        public string product_name { get; set; } // I stedet for at bruge products_id, anbefaler Jack at bruge et navn
        public int price { get; set; }
        public int quantity { get; set; }

    }
}
