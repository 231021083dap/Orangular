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
        private readonly IOrderItemRepository _orderItemsRepository;
        public OrderItemService(IOrderItemRepository orderItemsRepository)
        {
            _orderItemsRepository = orderItemsRepository;
        }
        public async Task<List<OrderItemResponse>> GetAll()
        {
            List<Order_Items> orderItems = await _orderItemsRepository.GetAll();
            return orderItems.Select(o => new OrderItemResponse
            {
                OrderItemID = o.order_items_id,
                Price = o.price,
                Quantity = o.quantity,
                Order = new OrderItem_OrderListResponse
                {
                   orderListID = o.order_list.order_lists_id,
                   orderDateTime = o.order_list.order_date_time
                },
                Product = new OrderItemProductResponse
                {
                    ProductID = o.product.products_id,
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
