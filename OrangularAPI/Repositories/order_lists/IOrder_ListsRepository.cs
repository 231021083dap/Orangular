using OrangularAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.Repositories.order_lists
{
    public interface IOrder_ListsRepository
    {
        Task<List<Order_Lists>> GetAll();
        Task<Order_Lists> GetById(int order_lists_id);
        Task<Order_Lists> Create(Order_Lists order_Lists);
        Task<Order_Lists> Update(int order_lists_id, Order_Lists order_Lists);
        Task<Order_Lists> Delete(int order_lists_id);
    }
}
