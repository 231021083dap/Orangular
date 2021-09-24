﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.DTO.OrderItems.Responses
{
    public class OrderItemResponse
    {
        public int OrderItemId { get; set; }

        public int Price { get; set; }
        
        public int Quantity { get; set; }

        public OrderItemProductResponse Product { get; set; }

        public OrderItemOrderListResponse Order { get; set; }
    }
}
