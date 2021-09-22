using Orangular.DTO.Order_Lists.Requests;
using Orangular.DTO.Order_Lists.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orangular.Services.Order_List
{
    public interface IOrder_ListsService
    {
        Task<List<Order_ListsResponse>> GetAllOrder_Lists();
        Task<Order_ListsResponse> GetById(int order_lists_id);
        Task<Order_ListsResponse> Create(NewOrder_Lists newOrder_Lists);
        Task<Order_ListsResponse> Update(int order_lists_id, UpdateOrder_Lists updateOrder_Lists);
        Task<bool> Delete(int order_lists_id);
    }
}
