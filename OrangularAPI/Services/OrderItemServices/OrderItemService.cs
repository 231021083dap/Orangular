﻿using OrangularAPI.Database.Entities;
using OrangularAPI.DTO.OrderItems.Responses;
using OrangularAPI.Repositories.OrderItemsRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.Services.OrderItemServices
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemsRepository;
        public OrderItemService(IOrderItemRepository orderItemsRepository)
        {
            _orderItemsRepository = orderItemsRepository;
        }
        public async Task<List<Order_ItemsResponse>> GetAll()
        {
            List<Order_Items> orderItems = await _orderItemsRepository.GetAll();
            return orderItems.Select(o => new Order_ItemsResponse
            {
                order_items_id = o.order_items_id,
                price = o.price,
                quantity = o.quantity,
                Order_Lists = new Order_ItemsOrder_ListsResponse
                {
                   order_lists_id = o.order_list.order_lists_id,
                   order_date_time = o.order_list.order_date_time
                },
                Products = new Order_ItemsProductsResponse
                {
                    products_id = o.product.products_id,
                    breed_name = o.product.breed_name,
                    price = o.product.price,
                    weight = o.product.weight,
                    gender = o.product.gender,
                    description = o.product.description
                }
            }).ToList();
        }
    }
}
