using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.DTO.OrderLists.Responses
{
    public class OrderListResponse
    {
        public int orderListID { get; set; }

        public DateTime orderDateTime { get; set; }

        public List<OrderList_OrderItemResponse> orderItem_orderItem { get; set; }

        public OrderList_UserResponse user { get; set; }


    }
}
