using Orangular.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orangular.Services.order_items
{
    interface IOrderItemsService
    {
        Task<List<Order_Items>> getAll();
        Task<Order_Items> getById(int orderItemsId);
        Task<Order_Items> create(Order_Items order_Items);
        Task<Order_Items> update(int orderItemsId, Order_Items order_Items);

    }
}
