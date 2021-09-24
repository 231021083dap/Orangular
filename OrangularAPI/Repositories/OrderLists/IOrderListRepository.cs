using OrangularAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.Repositories.OrderListsRepository
{
    public interface IOrderListRepository
    {
        Task<List<OrderList>> GetAll();
        Task<OrderList> GetById(int order_lists_id);
        Task<OrderList> Create(OrderList order_Lists);
        Task<OrderList> Update(int order_lists_id, OrderList order_Lists);
        Task<OrderList> Delete(int order_lists_id);
    }
}
