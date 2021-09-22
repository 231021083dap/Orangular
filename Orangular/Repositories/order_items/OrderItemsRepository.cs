using Microsoft.EntityFrameworkCore;
using Orangular.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orangular.Repositories.order_items
{
    public interface IOrderItemsRepository
    {
        Task<List<Order_Items>> GetAll();
        Task<Order_Items> GetById(int orderItemId);
        Task<Order_Items> Create(Order_Items order_Items);
        Task<Order_Items> Update(int orderItemId, Order_Items order_Item);
    }
    public class OrderItemsRepository : IOrderItemsRepository
    {
        private readonly OrangularProjectContext _context;
        public OrderItemsRepository(OrangularProjectContext context)
        {
            _context = context;
        }
        public async Task<List<Order_Items>> GetAll()
        {
            return await _context.Order_Items
                .Include(a => a.product)
                .Include(a => a.order_list)
                .ToListAsync();
        }
        public async Task<Order_Items> GetById(int orderItemId)
        {
            return await _context.Order_Items
                   .Include(a => a.product)
                   .Include(a => a.order_list)
                   .FirstOrDefaultAsync(a => a.order_items_id == orderItemId);
        }
        public async Task<Order_Items> Create(Order_Items order_Item)
        {
            _context.Order_Items.Add(order_Item);
            await _context.SaveChangesAsync();
            return order_Item;
        }
        public async Task<Order_Items> Update(int orderItemId, Order_Items order_Item)
        {
            Order_Items updateOrderItem = await _context.Order_Items.FirstOrDefaultAsync(a => a.order_items_id == orderItemId);
            if (updateOrderItem != null)
            {
                if (order_Item.price != 0) updateOrderItem.price = order_Item.price;
                if (order_Item.quantity != 0) updateOrderItem.quantity = order_Item.quantity;
                if (order_Item.order_items_id != 0) updateOrderItem.order_lists_id = order_Item.order_lists_id;
                if (order_Item.products_id != 0) updateOrderItem.products_id = order_Item.products_id;
                await _context.SaveChangesAsync();
            }
            return updateOrderItem;
        }
    }

}
