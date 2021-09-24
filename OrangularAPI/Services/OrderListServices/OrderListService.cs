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
        private readonly IOrderListRepository _order_ListsRepository;

        public OrderListService(IOrderListRepository order_ListsRepository)
        {
            _order_ListsRepository = order_ListsRepository;
        }
        public async Task<OrderListResponse> Create(NewOrderList newOrder_Lists)
        {
            Order_Lists order_Lists = new Order_Lists
            {
                users_id = newOrder_Lists.userID,
                order_date_time = newOrder_Lists.orderDateTime

            };

            order_Lists = await _order_ListsRepository.Create(order_Lists);

            return order_Lists == null ? null : new OrderListResponse
            {
                orderListID = order_Lists.order_lists_id,
                orderDateTime = order_Lists.order_date_time

            };
        }
        public async Task<List<OrderListResponse>> GetAll()
        {
            List<Order_Lists> order_Lists = await _order_ListsRepository.GetAll();

            return order_Lists.Select(a => new OrderListResponse
            {
                orderListID = a.order_lists_id,
                orderDateTime = a.order_date_time,


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
            Order_Lists order_Lists = await _order_ListsRepository.GetById(order_lists_id);
            return order_Lists == null ? null : new OrderListResponse
            {
                orderListID = order_Lists.order_lists_id,
                orderDateTime = order_Lists.order_date_time

            };
        }

        public async Task<OrderListResponse> Update(int order_lists_id, UpdateOrderList updateOrder_Lists)
        {
            Order_Lists order_Lists = new Order_Lists
            {
                order_date_time = updateOrder_Lists.orderDateTime,
                users_id = updateOrder_Lists.userID,

            };

            order_Lists = await _order_ListsRepository.Update(order_lists_id, order_Lists);

            return order_Lists == null ? null : new OrderListResponse
            {
                orderListID = order_lists_id,
                orderDateTime = order_Lists.order_date_time

            };
        }
        public async Task<bool> Delete(int order_lists_id)
        {
            var result = await _order_ListsRepository.Delete(order_lists_id);
            return (result != null);
        }

    }
}
