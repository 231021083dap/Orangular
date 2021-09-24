using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.DTO.OrderLists.Responses
{
    public class OrderListResponse
    {
        public int OrderListId { get; set; }

        public DateTime OrderDateTime { get; set; }

        public List<OrderListOrderItemResponse> OrderListOrderItem { get; set; }

        public OrderListUserResponse User { get; set; }


    }
}
