using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.DTO.Order_Lists.Responses
{
    public class Order_ListsResponse
    {
        public int order_lists_id { get; set; }

        public DateTime order_date_time { get; set; }

        public List<Order_ListsOrder_ItemsResponse> Order_Items { get; set; }

        public Order_ListsUsersResponse Users { get; set; }


    }
}
