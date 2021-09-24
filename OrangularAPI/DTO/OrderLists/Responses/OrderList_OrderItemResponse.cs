using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.DTO.OrderLists.Responses
{
    public class OrderList_OrderItemResponse
    {

        public int OrderItemId { get; set; }
        public string ProductName { get; set; } // I stedet for at bruge products_id, anbefaler Jack at bruge et navn
        public int Price { get; set; }
        public int Quantity { get; set; }

    }
}
