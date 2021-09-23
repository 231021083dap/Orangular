using OrangularAPI.DTO.OrderLists.Requests;
using OrangularAPI.DTO.OrderLists.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.Services.OrderListServices
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
