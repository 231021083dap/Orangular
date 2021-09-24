﻿using Microsoft.EntityFrameworkCore;
using OrangularAPI.Database;
using OrangularAPI.Database.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrangularAPI.Repositories.OrderListsRepository
{
    public class OrderListRepository : IOrderListRepository
    {
        private readonly OrangularProjectContext _context;

        public OrderListRepository(OrangularProjectContext context)
        {
            _context = context;
        }

        public async Task<OrderList> Create(OrderList order_Lists)
        {
            _context.OrderList.Add(order_Lists);
            await _context.SaveChangesAsync();
            return order_Lists;
        }

        public async Task<OrderList> Delete(int order_lists_id)
        {
            OrderList order_Lists = await _context.OrderList.FirstOrDefaultAsync(a => a.Id == order_lists_id);
            if (order_Lists != null)
            {
                _context.OrderList.Remove(order_Lists);
                await _context.SaveChangesAsync();
            }
            return order_Lists;
        }

        public async Task<List<OrderList>> GetAll()
        {
            return await _context.OrderList
              .ToListAsync();
        }

        public async Task<OrderList> GetById(int order_lists_id)
        {
            return await _context.OrderList.FirstOrDefaultAsync(a => a.Id == order_lists_id);
        }

        public async Task<OrderList> Update(int order_lists_id, OrderList order_Lists)
        {
            OrderList updateOrder_Lists = await _context.OrderList.FirstOrDefaultAsync(a => a.Id == order_lists_id);
            if (updateOrder_Lists != null)
            {
                updateOrder_Lists.User = order_Lists.User;
                await _context.SaveChangesAsync();
            }
            return updateOrder_Lists;
        }
    }
}
