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
        public async Task<OrderListResponse> Create(NewOrderList newOrderList)
        {
            OrderList orderList = new OrderList
            {
                // UserIdxxx = newOrderList.UserId,
                OrderDateTime = newOrderList.OrderDateTime

            };

            orderList = await _orderListRepository.Create(orderList);

            return orderList == null ? null : new OrderListResponse
            {
                OrderListId = orderList.Id,
                OrderDateTime = orderList.OrderDateTime

            };
        }
        public async Task<List<OrderListResponse>> GetAll()
        {
            List<OrderList> orderList = await _orderListRepository.GetAll();

            return orderList.Select(a => new OrderListResponse
            {
                OrderListId = a.Id,
                OrderDateTime = a.OrderDateTime,


                //    Books = a.Books.Select(b => new AuthorBookResponse
                //    {
                //        Id = b.Id,
                //        Title = b.Title,
                //        Pages = b.Pages
                //    }).ToList()
            }).ToList();
        }
        public async Task<OrderListResponse> GetById(int orderListId)
        {
            OrderList orderList = await _orderListRepository.GetById(orderListId);
            return orderList == null ? null : new OrderListResponse
            {
                OrderListId = orderList.Id,
                OrderDateTime = orderList.OrderDateTime

            };
        }

        public async Task<OrderListResponse> Update(int orderListId, UpdateOrderList updateOrderList)
        {
            OrderList orderList = new OrderList
            {
                OrderDateTime = updateOrderList.OrderDateTime,
                // UserIdxxx = updateOrderList.UserId,

            };

            orderList = await _orderListRepository.Update(orderListId, orderList);

            return orderList == null ? null : new OrderListResponse
            {
                OrderListId = orderListId,
                OrderDateTime = orderList.OrderDateTime

            };
        }
        public async Task<bool> Delete(int orderlistId)
        {
            var result = await _orderListRepository.Delete(orderlistId);
            return (result != null);
        }

    }
}
