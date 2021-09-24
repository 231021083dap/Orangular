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
        Task<List<OrderListResponse>> GetAll();
        Task<OrderListResponse> GetById(int order_lists_id);
        Task<OrderListResponse> Create(NewOrderList newOrder_Lists);
        Task<OrderListResponse> Update(int order_lists_id, UpdateOrderList updateOrder_Lists);
        Task<bool> Delete(int order_lists_id);
    }
}
