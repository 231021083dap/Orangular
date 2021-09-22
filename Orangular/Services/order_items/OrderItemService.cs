﻿using Orangular.Database.Entities;
using Orangular.DTO.Order_Items.Responses;
using Orangular.Repositories.order_items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orangular.Services.order_items
{
    public interface IOrderItemService
    {
        Task<List<Order_Items>> GetAll();
        //Task<Order_Items> GetById(int orderItemsId);
        //Task<Order_Items> Create(Order_Items order_Items);
        //Task<Order_Items> Update(int orderItemsId, Order_Items order_Items);
    }
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemsRepository _orderItemsRepository;
        public OrderItemService(IOrderItemsRepository orderItemsRepository)
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
                    //order_lists_id = o.order_list,
                    //order_date_time = o.
                }

            }).ToList();
        }
    }
}
