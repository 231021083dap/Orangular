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
                orderItemsID = o.order_items_id,
                price = o.price,
                quantity = o.quantity,
                orders = new OrderItem_OrderListResponse
                {
                   orderListID = o.order_list.order_lists_id,
                   orderDateTime = o.order_list.order_date_time
                },
                products = new OrderItemProductResponse
                {
                    productID = o.product.products_id,
                    breedName = o.product.breed_name,
                    price = o.product.price,
                    weight = o.product.weight,
                    gender = o.product.gender,
                    description = o.product.description
                }
            }).ToList();
        }
    }
}
