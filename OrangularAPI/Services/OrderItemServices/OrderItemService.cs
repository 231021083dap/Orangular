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
            List<Order_Items> orderItems = await _orderItemRepository.GetAll();
            return orderItems.Select(o => new OrderItemResponse
            {
                OrderItemId         = o.order_items_id,
                Price               = o.price,
                Quantity            = o.quantity,
                Order               = new OrderItemOrderListResponse
                {
                   OrderListId = o.order_list.order_lists_id,
                   OrderDateTime = o.order_list.order_date_time
                },
                Product = new OrderItemProductResponse
                {
                    ProductId = o.product.products_id,
                    BreedName = o.product.breed_name,
                    Price = o.product.price,
                    Weight = o.product.weight,
                    Gender = o.product.gender,
                    Description = o.product.description
                }
            }).ToList();
        }
    }
}
