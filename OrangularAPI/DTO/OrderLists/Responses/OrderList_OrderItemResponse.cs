using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.DTO.OrderLists.Responses
{
    public class OrderList_OrderItemResponse
    {

        public int orderItemID { get; set; }
        public string productName { get; set; } // I stedet for at bruge products_id, anbefaler Jack at bruge et navn
        public int price { get; set; }
        public int quantity { get; set; }

    }
}
