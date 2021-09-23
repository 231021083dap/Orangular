using Microsoft.EntityFrameworkCore;
using OrangularAPI.Database;
using OrangularAPI.Database.Entities;
using OrangularAPI.Repositories.order_lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.Repositories.order_lists
{
    public class Order_ListsRepository : IOrder_ListsRepository
    {
        private readonly OrangularProjectContext _context;

        public Order_ListsRepository(OrangularProjectContext context)
        {
            _context = context;
        }

        public async Task<Order_Lists> Create(Order_Lists order_Lists)
        {
            _context.Order_Lists.Add(order_Lists);
            await _context.SaveChangesAsync();
            return order_Lists;
        }

        public async Task<Order_Lists> Delete(int order_lists_id)
        {
            Order_Lists order_Lists = await _context.Order_Lists.FirstOrDefaultAsync(a => a.order_lists_id == order_lists_id);
            if (order_Lists != null)
            {
                _context.Order_Lists.Remove(order_Lists);
                await _context.SaveChangesAsync();
            }
            return order_Lists;
        }

        public async Task<List<Order_Lists>> GetAll()
        {
            return await _context.Order_Lists
              .ToListAsync();
        }

        public async Task<Order_Lists> GetById(int order_lists_id)
        {
            return await _context.Order_Lists.FirstOrDefaultAsync(a => a.order_lists_id == order_lists_id);
        }

        public async Task<Order_Lists> Update(int order_lists_id, Order_Lists order_Lists)
        {
            Order_Lists updateOrder_Lists = await _context.Order_Lists.FirstOrDefaultAsync(a => a.order_lists_id == order_lists_id);
            if (updateOrder_Lists != null)
            {
                updateOrder_Lists.user = order_Lists.user;
                await _context.SaveChangesAsync();
            }
            return updateOrder_Lists;
        }
    }
}
