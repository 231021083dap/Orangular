using OrangularAPI.Database.Entities;
using OrangularAPI.DTO.OrderLists.Requests;
using OrangularAPI.DTO.OrderLists.Responses;
using OrangularAPI.Repositories.OrderListsRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrangularAPI.Services.OrderListServices
{
    public class OrderListService : IOrderListService
    {
        private readonly IOrderListRepository _orderListRepository;

        public OrderListService(IOrderListRepository orderListRepository)
        {
            _orderListRepository = orderListRepository;
        }
        public async Task<OrderListResponse> Create(NewOrderList newOrder_Lists)
        {
            Order_Lists order_Lists = new Order_Lists
            {
                users_id = newOrder_Lists.UserId,
                order_date_time = newOrder_Lists.OrderDateTime

            };

            order_Lists = await _orderListRepository.Create(order_Lists);

            return order_Lists == null ? null : new OrderListResponse
            {
                OrderListId = order_Lists.order_lists_id,
                OrderDateTime = order_Lists.order_date_time

            };
        }
        public async Task<List<OrderListResponse>> GetAll()
        {
            List<Order_Lists> order_Lists = await _orderListRepository.GetAll();

            return order_Lists.Select(a => new OrderListResponse
            {
                OrderListId = a.order_lists_id,
                OrderDateTime = a.order_date_time,


                //    Books = a.Books.Select(b => new AuthorBookResponse
                //    {
                //        Id = b.Id,
                //        Title = b.Title,
                //        Pages = b.Pages
                //    }).ToList()
            }).ToList();
        }
        public async Task<OrderListResponse> GetById(int order_lists_id)
        {
            Order_Lists order_Lists = await _orderListRepository.GetById(order_lists_id);
            return order_Lists == null ? null : new OrderListResponse
            {
                OrderListId = order_Lists.order_lists_id,
                OrderDateTime = order_Lists.order_date_time

            };
        }

        public async Task<OrderListResponse> Update(int order_lists_id, UpdateOrderList updateOrder_Lists)
        {
            Order_Lists order_Lists = new Order_Lists
            {
                order_date_time = updateOrder_Lists.OrderDateTime,
                users_id = updateOrder_Lists.UserId,

            };

            order_Lists = await _orderListRepository.Update(order_lists_id, order_Lists);

            return order_Lists == null ? null : new OrderListResponse
            {
                OrderListId = order_lists_id,
                OrderDateTime = order_Lists.order_date_time

            };
        }
        public async Task<bool> Delete(int order_lists_id)
        {
            var result = await _orderListRepository.Delete(order_lists_id);
            return (result != null);
        }

    }
}
