using OrangularAPI.Database.Entities;
using OrangularAPI.DTO.Order_Items.Responses;
using OrangularAPI.Repositories.order_items;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.Services.OrderItemService
{
    public interface IOrderItemService
    {
        Task<List<Order_ItemsResponse>> GetAll();
    }
}