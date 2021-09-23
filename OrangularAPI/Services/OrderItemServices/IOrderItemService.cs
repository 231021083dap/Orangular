using OrangularAPI.DTO.OrderItems.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrangularAPI.Services.OrderItemServices
{
    public interface IOrderItemService
    {
        Task<List<Order_ItemsResponse>> GetAll();
    }
}