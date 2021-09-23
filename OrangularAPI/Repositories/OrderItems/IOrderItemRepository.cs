using Microsoft.EntityFrameworkCore;
using OrangularAPI.Database;
using OrangularAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.Repositories.OrderItemsRepository
{
    public interface IOrderItemRepository
    {
        Task<List<Order_Items>> GetAll();
        Task<Order_Items> GetById(int orderItemId);
        Task<Order_Items> Create(Order_Items order_Items);
        Task<Order_Items> Update(int orderItemId, Order_Items order_Item);
    }
}