using OrangularAPI.Database.Entities;
using OrangularAPI.DTO.OrderItems.Responses;
using OrangularAPI.Repositories.OrderItemsRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.Services.OrderItemServices
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        public OrderItemService(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }
        public async Task<List<OrderItemResponse>> GetAll()
        {
            List<OrderItem> orderItems = await _orderItemRepository.GetAll();
            return orderItems.Select(o => new OrderItemResponse
            {
                OrderItemId         = o.Id,
                Price               = o.Price,
                Quantity            = o.Quantity,
                Order               = new OrderItemOrderListResponse
                {
                   OrderListId = o.OrderList.Id,
                   OrderDateTime = o.OrderList.OrderDateTime
                },
                Product = new OrderItemProductResponse
                {
                    ProductId = o.Product.Id,
                    BreedName = o.Product.BreedName,
                    Price = o.Product.Price,
                    Weight = o.Product.Weight,
                    Gender = o.Product.Gender,
                    Description = o.Product.Description
                }
            }).ToList();
        }
    }
}
