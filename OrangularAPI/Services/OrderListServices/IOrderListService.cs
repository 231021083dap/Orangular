using OrangularAPI.DTO.Order_Lists.Requests;
using OrangularAPI.DTO.Order_Lists.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.Services.OrderListService
{
    public interface IOrderListService
    {
        Task<List<Order_ListsResponse>> GetAll();
        Task<Order_ListsResponse> GetById(int order_lists_id);
        Task<Order_ListsResponse> Create(NewOrder_Lists newOrder_Lists);
        Task<Order_ListsResponse> Update(int order_lists_id, UpdateOrder_Lists updateOrder_Lists);
        Task<bool> Delete(int order_lists_id);
    }
}
